using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users.Roles
{
    [PermissionsChecker(42)]
    public class EditModel : PageModel
    {
        private IUserRoleRepository _role;
        private IUserRoleService _roleService;

        public EditModel(IUserRoleRepository role, IUserRoleService roleService)
        {
            _role = role;
            _roleService = roleService;
        }
        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int roleId)
        {
            Role = _role.GetRoleById(roleId);
            if (Role==null)
            {
                Response.Redirect("/ManagementPanel/Users/Roles");
            }
        }

        public IActionResult OnPost(int roleId,List<int> permissions)
        {
            if (string.IsNullOrEmpty(Role.RoleTitle))
            {

                ModelState.AddModelError("RoleTitle","عنوان نقش را وارد کنید");
                return Page();
            }
            if (permissions.Count < 1)
            {
                ModelState.AddModelError("Permissions", "هر نقش حداقل باید یک دسترسی داشته باشد");
                return Page();
            }
            var role = _role.FindRole(roleId);
            role.RoleTitle = Role.RoleTitle;
            _roleService.EditRole(role,permissions);
            return RedirectToPage("Index");
        }
    }
}
