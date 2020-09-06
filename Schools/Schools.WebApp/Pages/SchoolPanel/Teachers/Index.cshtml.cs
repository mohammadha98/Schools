using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.SchoolPanel.Teachers
{
    [PermissionsChecker(3)]

    public class IndexModel : PageModel
    {
        private ISchoolTeacherRepository _teacher;
        private ISchoolRepository _school;
        private IUserRoleRepository _role;

        public IndexModel(ISchoolTeacherRepository teacher, ISchoolRepository school, IUserRoleRepository role)
        {
            _teacher = teacher;
            _school = school;
            _role = role;
        }
  
       
        [BindProperty]
        public SchoolTeacher Teacher { get; set; }
        public List<SchoolTeacher> SchoolTeachers { get; set; }
        public School School { get; set; }
        public void OnGet()
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School == null)
            {
                Response.Redirect("/");
            }
            
            SchoolTeachers = _teacher.GetTeachersBySchoolId(School!.SchoolId).ToList();
        }

        public IActionResult OnPost()
        {
            if (!_role.CheckPermission(User.GetUserId(),10))
            {
                return Redirect("/SchoolPanel");
            }



            var school = _school.GetSchoolByUserId(User.GetUserId());
            if (school == null)
            {
                return Redirect("/");
            }
            Teacher.SchoolId = school.SchoolId;
            Teacher.IsActive = false;
            Teacher.IsDelete = false;
            if (!ModelState.IsValid)
            {
                School = school;
                return Page();
            }
            TempData["Success"] = true;
            _teacher.AddTeacher(Teacher);
            return Redirect("/SchoolPanel/Teachers");
        }
    }
}
