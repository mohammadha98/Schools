using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools.Teacher;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Teachers
{
    public class IndexModel : PageModel
    {
        private ISchoolTeacherRepository _teacher;
        private ISchoolRepository _school;
        private ISchoolTeacherService _teacherService;

        public IndexModel(ISchoolTeacherRepository teacher, ISchoolRepository school, ISchoolTeacherService teacherService)
        {
            _teacher = teacher;
            _school = school;
            _teacherService = teacherService;
        }
   

        public List<SchoolTeacher> SchoolTeachers { get; set; }
        public void OnGet(int schoolId)
        {
            var school = _school.GetSchoolBySchoolId(schoolId);
            if (school == null)
            {
                Response.Redirect("/ManagementPanel/Schools");
            }
            else
            {
                ViewData["School"] = school;
                SchoolTeachers = _teacher.GetTeachersBySchoolId(schoolId).ToList();
            }

        }

        public IActionResult OnGetDeleteTeacher(int teacherId)
        {
            var teacher = _teacher.GetTeacherById(teacherId);
            if (teacher == null)
                return Content("NotFound");
            _teacherService.DeleteTeacher(teacherId);
            return Content("Deleted");
        }
    }
}
