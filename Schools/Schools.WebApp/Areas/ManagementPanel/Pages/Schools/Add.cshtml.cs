using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools
{
    [PermissionsChecker(34)]
    public class AddModel : PageModel
    {
        private ISchoolService _school;
        private IUserRepository _user;

        public AddModel(ISchoolService school, IUserRepository user)
        {
            _school = school;
            _user = user;
        }
        [BindProperty]
        public AddSchoolViewModel School { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (School.ShireId == 0 || School.CityId == 0)
            {
                ModelState.AddModelError("ShireId", "لطفا موقعیت مکانی آموزشگاه را انتخاب کنید");
                return Page();
            }
            if (School.GroupId == 0)
            {
                ModelState.AddModelError("GroupId", "لطفا گروه آموزشگاه را انتخاب کنید");
                return Page();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (_user.GetUserById(School.SchoolManager) == null)
            {
                ModelState.AddModelError("SchoolManager", "کاربری با شناسه وارد شده وجود ندارد");
                return Page();
            }
            if (_school.IsUserHasSchool(School.SchoolManager))
            {
                ModelState.AddModelError("SchoolManager", "شناسه وارد شده دارای آموزشگاه می باشد");
                return Page();
            }
            var result = _school.AddNewSchool(School);

            if (result == false)
            {
                ModelState.AddModelError("avatar", "شما فقط مجاز به انتخاب عکس می باشید");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
