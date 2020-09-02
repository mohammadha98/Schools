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
using Microsoft.AspNetCore.Http;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users
{
    public class AddModel : PageModel
    {
        private IUserRepository _userRepository;
        private IUserRoleRepository _role;

        public AddModel(IUserRepository userRepository, IUserRoleRepository role)
        {
            _userRepository = userRepository;
            _role = role;
        }
    
        
        public List<Role> Roles { get; set; }
        [BindProperty]
        public AddUserViewModel Add { get; set; }

        public void OnGet()
        {
            Roles = _role.GetAllRoles().ToList();
        }

        public IActionResult OnPost(List<int> selectedRoles,IFormFile file)
        {
            if (!ModelState.IsValid)
                return Page();


            if (file.FileName != "" || file.FileName != null)
            {
                if (file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".png"))
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserProfile", file.FileName + Guid.NewGuid().ToString());
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }
                }
            }

            User user = new User() 
            { 
                Family = Add.Family,
                Name = Add.Name,
                RegisterDate = DateTime.Now,
                IsDelete = false,
                UserName = Add.UserName,
                UserAvatar = file.FileName,
                IsActive = true,
                Password = PasswordHelper.EncodePasswordMd5(Add.Password)
            };
            
            var userId = _userRepository.AddUser(user);
            _role.AddRolesForUser(selectedRoles, userId);

            return RedirectToPage("Index");
        }
    }
}
