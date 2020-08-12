using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users
{
    public class AddModel : PageModel
    {
        private IUserRepository _userRepository;
        public AddModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<Role> Roles { get; set; }
        [BindProperty]
        public User add { get; set; }
        public void OnGet()
        {
            Roles = _userRepository.GetAllRoles();
        }
    }
}
