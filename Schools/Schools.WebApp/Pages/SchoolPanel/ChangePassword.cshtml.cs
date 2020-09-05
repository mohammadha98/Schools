using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.WebApp.Pages.SchoolPanel
{
    public class ChangePasswordModel : PageModel
    {
        private IUserService _service;

        public ChangePasswordModel(IUserService service)
        {
            _service = service;
        }
        [BindProperty]
        public ChangePasswordViewModel Password { get; set; }
        public void OnGet()
        {
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
