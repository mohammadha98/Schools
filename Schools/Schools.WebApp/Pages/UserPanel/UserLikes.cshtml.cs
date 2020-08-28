using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.UserPanel
{
    
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
