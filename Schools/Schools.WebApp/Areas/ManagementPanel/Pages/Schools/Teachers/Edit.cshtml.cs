using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Teachers
{
    [PermissionsChecker(33)]
    public class EditModel : PageModel
    {
        private ISchoolTeacherRepository _teacher;
        private ISchoolRepository _school;
        private IUserRepository _user;

        public EditModel(ISchoolTeacherRepository teacher, ISchoolRepository school, IUserRepository user)
        {
            _teacher = teacher;
            _school = school;
            _user = user;
        }


        [BindProperty]
        public SchoolTeacher SchoolTeacher { get; set; }
        public void OnGet(int teacherId,int schoolId)
        {
            if (!_school.IsSchoolExist(schoolId))
            {
                Response.Redirect("/ManagementPanel/Schools");
            }

            var teacher = _teacher.GetTeacherById(teacherId);
            if (teacher==null)
            {
                Response.Redirect("/ManagementPanel/Schools");
            }
            else
            {
                SchoolTeacher = teacher;
            }
        }

        public IActionResult OnPost(int teacherId, int schoolId)
        {
            SchoolTeacher.TeacherId = teacherId;
            SchoolTeacher.SchoolId = schoolId;
           

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _teacher.EditTeacher(SchoolTeacher);
            return Redirect("/ManagementPanel/Schools/Teachers/" + schoolId);
        }
    }
}
