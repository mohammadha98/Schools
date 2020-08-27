using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.UserPanel
{
    public class RatesModel : PageModel
    {
        private IUserRepository _user;

        public RatesModel(IUserRepository user)
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
