using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Pages.SchoolPanel
{
    public class ChangePasswordModel : PageModel
    {
        private IUserService _service;
        private ISchoolRepository _school;

        public ChangePasswordModel(IUserService service, ISchoolRepository school)
        {
            _service = service;
            _school = school;
        }

        [BindProperty]
        public ChangePasswordViewModel Password { get; set; }

        public School School { get; set; }
        public void OnGet()
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School == null)
            {
                Response.Redirect("/");
            }
        }

        public IActionResult OnPost()
        {
            Password.UserId = User.GetUserId();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = _service.ChangePassword(Password);
            if (res == false)
            {
                ModelState.AddModelError("CurrentPassword", "رمز عبور فعلی شما نا معتبر است");
                return Page();
            }
            TempData["EditSuccess"] = true;
            return RedirectToPage("Index");
        }
    }
}
