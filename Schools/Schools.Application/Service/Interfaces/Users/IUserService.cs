using Schools.Application.ViewModels.UsersViewModel;
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
    }
}
