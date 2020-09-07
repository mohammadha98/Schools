using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Courses
{
    [PermissionsChecker(31)]
    public class AddModel : PageModel
    {
        private ISchoolCourseRepository _course;

        public AddModel(ISchoolCourseRepository course)
        {
            _course = course;
        }
        [BindProperty]
        public SchoolCourse SchoolCourse { get; set; }
        public void OnGet(int schoolId)
        {
        }

        public IActionResult OnPost(int schoolId)
        {
            SchoolCourse.SchoolId = schoolId;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _course.AddCourse(SchoolCourse);
            return Redirect("/ManagementPanel/Schools/Courses/" + schoolId);
        }
    }
}
