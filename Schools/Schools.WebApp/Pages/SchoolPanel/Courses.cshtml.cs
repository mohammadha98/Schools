using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Pages.SchoolPanel
{
    public class CoursesModel : PageModel
    {
        private ISchoolRepository _school;
        private ISchoolCourseRepository _course;

        public CoursesModel(ISchoolRepository school, ISchoolCourseRepository course)
        {
            _school = school;
            _course = course;
        }

        [BindProperty]
        public SchoolCourse Course { get; set; }
        public List<SchoolCourse> SchoolCourses { get; set; }
        public School School { get; set; }
        public void OnGet()
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School == null)
            {
                Response.Redirect("/");
            }
            else
            {
                SchoolCourses = _course.GetCoursesBySchoolId(School.SchoolId);
            }

        }

        public IActionResult OnPost()
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School == null)
            {
                return Forbid();
            }
            Course.IsActive = false;
            Course.IsDelete = false;
            Course.SchoolId = School.SchoolId;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _course.AddCourse(Course);
            TempData["Success"] = true;
            return Redirect("/SchoolPanel/Courses");
        }
    }
}
