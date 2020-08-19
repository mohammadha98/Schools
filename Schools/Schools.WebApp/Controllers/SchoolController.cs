using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Application.Service.Interfaces.Schools;

namespace Schools.WebApp.Controllers
{
    public class SchoolController : Controller
    {
        private ISchoolService _school;
        private ILocationService _locationService;
        private ISchoolCommentService _comment;

        public SchoolController(ISchoolService school, ILocationService locationService, ISchoolCommentService comment)
        {
            _school = school;
            _locationService = locationService;
            _comment = comment;
        }
     
        [Route("/School/{schoolId}/{schoolTitle}")]
        public IActionResult SinglePage(int schoolId,string schoolTitle)
        {
            var school = _school.GetSchoolById(schoolId);
            if (school == null)
            {
                return NotFound();
            }

            ViewData["Shires"] = _locationService.GetAllShire();
            ViewData["Cities"] = _locationService.GetAllCityByShireId(school.ShireId);
            //پر کردن اولیه بخش نظرات
            ViewData["Comments"] = _comment.GetSchoolComments(1, 2, schoolId);
            return View(school);
        }
        [Route("/Schools")]
        public IActionResult SchoolCategory(int page = 1, string shireTitle = "", string cityTitle = "", string categoryTitle = "", string schoolName = "", string courseName = "", string teacherName = "", string orderBy = "all")
        {
            var model = _school.GetSchoolsForCategory(page, 20, shireTitle, cityTitle, categoryTitle, schoolName,
                courseName, teacherName, orderBy);
            if (!string.IsNullOrEmpty(shireTitle))
            {
                model.Cities = _locationService.GetAllCityByShireTitle(shireTitle);
            }
            return View("SchoolsCategory", model);
        }
        [Route("/GetComments/{pageId}/{schoolId}")]
        public IActionResult GetSchoolComments(int pageId, int schoolId)
        {
            //var pageModel = ;
            var school = _comment.GetSchoolComments(pageId, 2, schoolId);
            if (school == null)
            {
                return NotFound();
            }
            return Ok(school);
        }
    }
    
}