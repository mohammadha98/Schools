using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users
{
    public class IndexModel : PageModel
    {
        private IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        public UsersForAdminPanelViewModel usersForAdminPanelViewModel { get; set; }

        public void OnGet(int pageId = 1, string username = "")
        {
            usersForAdminPanelViewModel = _userService.GetUsersByFilter(username, pageId);
        }

    }
}
