﻿using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Repository.InterfaceRepository.Locations;

namespace Schools.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ILocationRepository _location;
        private ISchoolService _school;
        private ILocationService _locationService;

        public HomeController(ILocationRepository location, ISchoolService school, ILocationService locationService)
        {
            _location = location;
            _school = school;
            _locationService = locationService;
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
        [Route("/Schools")]
        public IActionResult SchoolCategory(int page=1,string shireTitle="",string cityTitle="",string categoryTitle="",string schoolName="",string courseName="",string teacherName="",string orderBy="all")
        {
            var model = _school.GetSchoolsForCategory(page, 20, shireTitle, cityTitle, categoryTitle, schoolName,
                courseName, teacherName, orderBy);
            if (!string.IsNullOrEmpty(shireTitle))
            {
                model.Cities = _locationService.GetAllCityByShireTitle(shireTitle);
            }
            return View("SchoolsCategory",model);
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
        [Route("/GetCityByShireId/{shireTitle}")]
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
       
    }
}