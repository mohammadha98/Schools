using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Models.AboutUs;
using Schools.Domain.Repository.InterfaceRepository.Locations;

namespace Schools.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ILocationRepository _location;
        private ISchoolService _school;
        private ILocationService _locationService;
        private IContactUsRepository _contactUs;
        private IAboutUsRepository _aboutUs;
        private IContactUsFormRepository _contactUsForm;

        public HomeController(ILocationRepository location, ISchoolService school, ILocationService locationService, IContactUsRepository contactUs, IAboutUsRepository aboutUs, IContactUsFormRepository contactUsForm)
        {
            _location = location;
            _school = school;
            _locationService = locationService;
            _contactUs = contactUs;
            _aboutUs = aboutUs;
            _contactUsForm = contactUsForm;
        }


        [Route("/{englishName}")]
        public IActionResult Index(string englishName)
        {
            var shire = _location.GetShireByEnglishName(englishName);

            if (shire != null)
            {
                var pageModel = _school.GetSchoolsForMainPage(shire.ShireTitle);

                return View(pageModel);
            }

            return NotFound();
        }

        [Route("/Home/HandleError/{code}")]
        public IActionResult HandlerError(int code)
        {
       

            if (code >= 500)
            {
                return View("ServerError");
            }

            return View("NotFound");

        }
        [Route("/GetCityByShireTitle/{shireTitle}")]
        public string GetCities(string shireTitle)
        {
            var cities = _locationService.GetAllCityByShireTitle(shireTitle);

            string result = "<option value =''> انتخاب شهر</option>";
            foreach (var city in cities)
            {
                result += $"<option value='{city.CityTitle}'>{city.CityTitle}</option>";
            }
            return result;
        }
        [Route("/GetCityByShireId/{shireId}")]
        public string GetCitiesByShireId(int shireId)
        {
            var cities = _locationService.GetAllCityByShireId(shireId);

            string result = "<option value ='0'> انتخاب شهر</option>";
            foreach (var city in cities)
            {
                result += $"<option value='{city.CityId}'>{city.CityTitle}</option>";
            }
            return result;
        }

        [Route("/AboutUs")]
        public IActionResult AboutUs(AboutUs aboutUs)
        {
            var aboutus = _aboutUs.GetLast();
            return View(aboutus);
        }
        [Route("/ContactUs")]
        public IActionResult ContactUs()
        {
            return View(_contactUs.GetLast());
        }
        [HttpPost]
        [Route("/ContactUs")]
        public IActionResult ContactUs(ContactUsForm contactUsForm)
        {
            if (!ModelState.IsValid)
                return View(_contactUs.GetLast());

            _contactUsForm.InsertQuestion(contactUsForm);
            ViewData["IsSuccess"] = true;
            return View(_contactUs.GetLast());
        }
    }
}