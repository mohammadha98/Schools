using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.UserPanel
{
    //2 = دانشجو
    [PermissionsChecker(2)]
    public class IndexModel : PageModel
    {
        private IUserRepository _user;

        public IndexModel(IUserRepository user)
        {
            _user = user;
        }
        public User UserModel { get; set; }
        public void OnGet()
        {
            UserModel = _user.GetUserWithRelations(User.GetUserId());
        }
        
    }
}
