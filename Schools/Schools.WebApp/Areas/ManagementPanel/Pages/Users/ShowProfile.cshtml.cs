using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users
{
    [PermissionsChecker(39)]
    public class ShowProfileModel : PageModel
    {
       
        private IUserRepository _UserRepository;

        public ShowProfileModel(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public User UserModel { get; set; }

        public void OnGet(int userId)
        {
            UserModel = _UserRepository.GetUserWithRelations(userId);
            if (UserModel == null) Response.Redirect("/ManagementPanel/Users");
        }
    }
}
