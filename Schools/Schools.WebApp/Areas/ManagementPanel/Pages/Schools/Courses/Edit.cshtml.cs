using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Courses
{
    [PermissionsChecker(31)]

    public class EditModel : PageModel
    {
        private ISchoolCourseRepository _course;

        public EditModel(ISchoolCourseRepository course)
        {
            _course = course;
        }
        [BindProperty]
        public SchoolCourse SchoolCourse { get; set; }
        public void OnGet(int courseId, int schoolId)
        {
            SchoolCourse = _course.GetCourseById(courseId);
            if (SchoolCourse == null || SchoolCourse.SchoolId != schoolId)
            {
                Response.Redirect("/managementPanel/Schools");
            }

        }

        public IActionResult OnPost(int courseId, int schoolId)
        {
            SchoolCourse.SchoolId = schoolId;
            SchoolCourse.CourseId = courseId;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _course.EditCourse(SchoolCourse);
            return Redirect("/ManagementPanel/Schools/Courses/" + schoolId);

        }
    }
}
