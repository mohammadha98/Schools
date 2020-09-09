using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users
{
    [PermissionsChecker(36)]

    public class IndexModel : PageModel
    {
        private IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        public UsersForAdminPanelViewModel UsersModel { get; set; }

        public void OnGet(int pageId = 1, string userName = "",string phoneNumber="",string email="",string isActive="",string name="",string family="")
        {
            UsersModel = _userService.GetUsersByFilter(pageId,15,name,family,email,isActive,userName,phoneNumber);
        }

    }
}
