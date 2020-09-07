﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.WebApp.Pages.UserPanel
{
    //12 = ویرایش حساب کاربری
    [PermissionsChecker(12)]
    public class EditModel : PageModel
    {
        private IUserService _service;

        public EditModel(IUserService service)
        {
            _service = service;
        }
        [BindProperty]
        public EditUserInfoViewModel UserModel { get; set; }
        public void OnGet()
        {
           
        }

        public IActionResult OnPost()
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
