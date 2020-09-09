using Microsoft.AspNetCore.Http;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users;


namespace Schools.Application.Service.Interfaces.Users
{
    public interface IUserService
    {
        #region AdminPanel
        UsersForAdminPanelViewModel GetUsersByFilter(int pageId,int take,string name,string family,string email,string isActive,string userName,string phoneNumber);
        bool AddUser(User user,IFormFile imageAvatar);
        bool EditUser(User user,IFormFile imageAvatar);
        #endregion

        #region AccountServices
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        bool ActiveAccount(string activeCode);
        User LoginUser(LoginViewModel login);
        void RegisterUser(RegisterViewModel register);
        void ForgotPassword(User user,string hostName);
        bool ChangePassword(ChangePasswordModel passwordModel);
        #endregion

        #region UserPanel
        void EditUserInfo(EditUserInfoViewModel editModel);
        bool ChangePassword(ChangePasswordViewModel password);

        #endregion
    }
}
