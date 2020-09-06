using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.SchoolPanel
{
    [PermissionsChecker(3)]
    public class CoursesModel : PageModel
    {
        private ISchoolRepository _school;
        private ISchoolCourseRepository _course;
        private IUserRoleRepository _role;

        public CoursesModel(ISchoolRepository school, ISchoolCourseRepository course, IUserRoleRepository role)
        {
            _school = school;
            _course = course;
            _role = role;
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
            if (!_role.CheckPermission(User.GetUserId(), 4))
            {
                return RedirectToPage("Index");
            }

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
