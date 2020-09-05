using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Courses
{
    public class IndexModel : PageModel
    {
        private ISchoolCourseRepository _course;
        private ISchoolService _school;

        public IndexModel(ISchoolCourseRepository course, ISchoolService school)
        {
            _course = course;
            _school = school;
        }
     
        public List<SchoolCourse> SchoolCourses { get; set; }
        public School School { get; set; }
        public void OnGet(int schoolId)
        {
            School = _school.GetSchoolById(schoolId);
            if (School==null)
            {
                Response.Redirect("/ManagementPanel/Schools");
            }
            else
            {
                SchoolCourses = _course.GetCoursesBySchoolId(schoolId);
            }
        }
        public IActionResult OnGetDeleteCourse(int schoolId,int courseId)
        {
            var course = _course.GetCourseById(courseId);
            if (course == null) return Content("NotFound");
            if (course.SchoolId != schoolId) return Content("NotFound");
            
            _course.DeleteCourse(course);
            return Content("Deleted");
        }
    }
}
