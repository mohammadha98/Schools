using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.Service.Interfaces.Users
{
    public interface IUserService
    {
        #region AdminPanel
        UsersForAdminPanelViewModel GetUsersByFilter(string username = "",int pageId = 1);
        UserInfoViewModel GetUserInfoByUserId(int userId);

        #endregion

        #region AccountServices
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        bool ActiveAccount(string activeCode);
        #endregion
    }
}
