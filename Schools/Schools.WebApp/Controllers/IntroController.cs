using Microsoft.AspNetCore.Mvc;
using Schools.Domain.Repository.InterfaceRepository.Locations;

namespace Schools.WebApp.Controllers
{
    public class IntroController : Controller
    {
        private ILocationRepository _location;

        public IntroController(ILocationRepository location)
        {
            _location = location;
        }
        public IActionResult Index()
        {

            return View(_location.GetAllShires());
        }

        public IActionResult GetShireInfo(string title)
        {
            var shire = _location.GetShireByTitle(title);
            if (shire == null)
            {
                return Content("Error");
            }
            //Return Schools Count
            return Content(shire.Schools.Count.ToString());
        }

     

    }
}