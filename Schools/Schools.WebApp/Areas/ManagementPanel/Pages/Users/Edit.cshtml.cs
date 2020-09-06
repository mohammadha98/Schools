using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users
{
    public class EditModel : PageModel
    {
        private IUserRepository _userRepository;
        private IUserRoleRepository _role;
        private IUserService _user;

        public EditModel(IUserRepository userRepository, IUserRoleRepository role, IUserService user)
        {
            _userRepository = userRepository;
            _role = role;
            _user = user;
        }
 

        public List<Role> Roles { get; set; }
        [BindProperty]
        public User UserModel { get; set; }
        public void OnGet(int userId)
        {
            UserModel = _userRepository.GetUserById(userId);
            if (UserModel==null)
            {
                Response.Redirect("/ManagementPanel/Users");
            }
            Roles = _role.GetAllRoles().ToList();

        }

        public IActionResult OnPost(int userId, IFormFile imageAvatar,List<int> roles)
        {
            var user = _userRepository.FindUser(userId);
            user.NationalCode = UserModel.NationalCode;
            user.Name = UserModel.Name;
            user.Family = UserModel.Family;
            user.PhoneNumber = UserModel.PhoneNumber;
            user.IsActive = UserModel.IsActive;
            user.TelNumber = UserModel.TelNumber;
            user.Description = UserModel.Description;
            var res=_user.EditUser(user, imageAvatar);
            if (res==false)
            {
                ModelState.AddModelError("UserAvatar", "عکس نا معتبر است");

                return Page();
            }

            _role.RemoveUserRole(userId);
            _role.AddRolesForUser(roles, userId);
            return RedirectToPage("Index");
        }
    }
}
