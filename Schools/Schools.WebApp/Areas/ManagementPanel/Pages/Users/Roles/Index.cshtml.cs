using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users.Roles
{
    public class IndexModel : PageModel
    {
        private IUserRoleRepository _role;
        private IUserRoleService _roleService;

        public IndexModel(IUserRoleRepository role, IUserRoleService roleService)
        {
            _role = role;
            _roleService = roleService;
        }


        public List<Role> Roles { get; set; }
        public void OnGet()
        {
            Roles = _role.GetAllRoles().ToList();
        }

        public IActionResult OnGetDeleteRole(int roleId)
        {
            var res = _roleService.DeleteRole(roleId);
            return res ? Content("Deleted") : Content("Error");
        }
    }
}
