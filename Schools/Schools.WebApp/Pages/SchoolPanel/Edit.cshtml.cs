using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.WebApp.Pages.SchoolPanel
{
    public class EditModel : PageModel
    {
        private IUserService _service;

        public EditModel(IUserService service)
        {
            _service = service;
        }
        public EditUserInfoViewModel UserModel { get; set; }
        public void OnGet()
        {

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
