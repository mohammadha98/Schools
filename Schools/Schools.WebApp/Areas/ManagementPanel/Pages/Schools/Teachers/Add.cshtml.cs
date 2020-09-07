using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Teachers
{
    [PermissionsChecker(33)]
    public class AddModel : PageModel
    {
        private ISchoolTeacherRepository _teacher;
        private ISchoolRepository _school;


        public AddModel(ISchoolTeacherRepository teacher, ISchoolRepository school)
        {
            _teacher = teacher;
            _school = school;
        }
      
    
        [BindProperty]
        public SchoolTeacher SchoolTeacher { get; set; }
        public void OnGet(int schoolId)
        {
            if (!_school.IsSchoolExist(schoolId))
            {
                Response.Redirect("/ManagementPanel/Schools");
            }
        }

        public IActionResult OnPost(int schoolId)
        {
            SchoolTeacher.SchoolId = schoolId;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _teacher.AddTeacher(SchoolTeacher);
            return Redirect("/ManagementPanel/Schools/Teachers/" + schoolId);
        }
    }
}
