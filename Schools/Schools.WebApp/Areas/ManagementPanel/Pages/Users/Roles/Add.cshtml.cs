using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.ViewModels;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users.Roles
{
    public class AddModel : PageModel
    {
        private IUserRoleService _role;

        public AddModel(IUserRoleService role)
        {
            _role = role;
        }
        [BindProperty]
        public AddRoleViewModel RoleModel { get; set; }
        public void OnGet()
        {
           
        }

        public IActionResult OnPost(List<int> permissions)
        {
            RoleModel.Permissions = permissions;
            if (string.IsNullOrEmpty(RoleModel.RoleTitle))
            {
                ModelState.AddModelError("RoleTitle", "عنوان نقش را وارد کنید");
                return Page();
            }
            if (RoleModel.Permissions.Count<1)
            {
                ModelState.AddModelError("Permissions","هر نقش حداقل باید یک دسترسی داشته باشد");
                return Page();
            }
            _role.AddRole(RoleModel);
            return RedirectToPage("Index");
        }
    }
}
