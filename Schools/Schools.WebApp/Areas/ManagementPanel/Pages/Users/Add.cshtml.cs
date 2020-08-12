using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Domain.Models.Users;
using Schools.Application.Utilities.Security;
using Microsoft.AspNetCore.Identity;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users
{
    public class AddModel : PageModel
    {
        private IUserRepository _userRepository;
        public AddModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User UserAdd { get; set; }
        public List<Role> Roles { get; set; }
        [BindProperty]
        public AddUserViewModel add { get; set; }
        public void OnGet()
        {
            Roles = _userRepository.GetAllRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if (!ModelState.IsValid)
                return Page();

            if (add.Image.FileName != "" || add.Image.FileName != null)
            {
                if (add.Image.ContentType.EndsWith("jpg") || add.Image.ContentType.EndsWith("ong"))
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "www/UserProfile", add.Image.FileName + Guid.NewGuid().ToString());
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        add.Image.CopyTo(fs);
                    }
                }
            }

            UserAdd.UserName = add.UserName;
            UserAdd.Name = add.Name;
            UserAdd.RegisterDate = DateTime.Now;
            UserAdd.IsDelete = false;
            UserAdd.Family = add.Family;
            UserAdd.UserAvatar = add.Image.FileName;
            UserAdd.IsActive = true;
            UserAdd.Password = PasswordHelper.EncodePasswordMd5(add.Password);

            var userId = _userRepository.AddUser(UserAdd);
            _userRepository.AddRolesForUser(SelectedRoles, userId);

            return Page();
        }
    }
}
