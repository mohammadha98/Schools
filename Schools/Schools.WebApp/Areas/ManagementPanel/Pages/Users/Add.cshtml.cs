using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Application.Utilities.Security;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users
{
    [PermissionsChecker(37)]

    public class AddModel : PageModel
    {
        private IUserService _user;
        private IUserRoleRepository _role;

        public AddModel(IUserService user, IUserRoleRepository role)
        {
            _user = user;
            _role = role;
        }
    
        
        public List<Role> Roles { get; set; }
        [BindProperty]
        public User UserModel { get; set; }

        public void OnGet()
        {
            Roles = _role.GetAllRoles().ToList();
        }

        public IActionResult OnPost(List<int> selectedRoles,IFormFile imageAvatar)
        {
            Roles = _role.GetAllRoles().ToList();

            if (!ModelState.IsValid)
                return Page();

            if (_user.IsExistEmail(UserModel.Email))
            {
                ModelState.AddModelError("Email","ایمیل تکراری است");
                return Page();
            }
            if (_user.IsExistUserName(UserModel.UserName))
            {
                ModelState.AddModelError("Email", "نام کاربری تکراری است");
                return Page();
            }
            var res = _user.AddUser(UserModel, imageAvatar);
            if (res==false)
            {
                ModelState.AddModelError("UserAvatar","عکس نا معتبر است");
                return Page();
            }
            _role.AddRolesForUser(selectedRoles, UserModel.UserId);

            return RedirectToPage("Index");
        }
    }
}
