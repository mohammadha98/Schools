using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Pages.SchoolPanel
{
    [PermissionsChecker(48)]
    public class EditModel : PageModel
    {
        private IUserService _service;
        private ISchoolRepository _school;

        public EditModel(IUserService service)
        {
            _service = service;
        }

        public School School { get; set; }
        [BindProperty]
        public EditUserInfoViewModel UserModel { get; set; }
        public void OnGet()
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School==null)
            {
                Response.Redirect("/");
            }
        }
        public IActionResult OnPost(string description)
        {

            UserModel.UserId = User.GetUserId();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _service.EditUserInfo(UserModel);
            TempData["EditSuccess"] = true;
            return RedirectToPage("Index");
        }
    }
}
