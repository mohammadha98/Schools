using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Teachers
{
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
            
            var teacher = _teacher.GetTeacherById(teacherId);
            teacher.Bio = SchoolTeacher.Bio;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!_user.IsUserExist(SchoolTeacher.UserId))
            {
                ModelState.AddModelError("UserId", "شناسه کاربری نامعتبر است");
                return Page();

            }
            //اگر شناسه کاربری تغییر داده شده بود وارد شرط میشه
            if (teacher.UserId != SchoolTeacher.UserId)
            {
                teacher.UserId = SchoolTeacher.UserId;
                //اگر شناسه وارد شده قبلا در این آموزشگاه مدرس بوده باشه وارد شرط میشه
                if (_teacher.IsUserIsTeacherInSchool(SchoolTeacher.UserId, schoolId))
                {
                    ModelState.AddModelError("UserId", "کاربر انتخابی خود یک مدرس است");
                    return Page();
                }
            }
            _teacher.EditTeacher(teacher);
            return Redirect("/ManagementPanel/Schools/Teachers/" + schoolId);
        }
    }
}
