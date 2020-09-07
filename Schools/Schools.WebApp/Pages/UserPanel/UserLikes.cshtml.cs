using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.UserPanel
{
    //2 = دانشجو
    [PermissionsChecker(2)]
    public class UserLikesModel : PageModel
    {
        private IUserRepository _repository;

        public UserLikesModel(IUserRepository repository)
        {
            _repository = repository;
        }
        public User UserModel { get; set; }
        public void OnGet()
        {
            UserModel = _repository.GetUserWithRelations(User.GetUserId());
        }
    }
}
