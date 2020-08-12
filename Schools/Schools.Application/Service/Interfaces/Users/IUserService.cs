using Schools.Application.ViewModels.UsersViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.Service.Interfaces.Users
{
    public interface IUserService
    {
        UsersForAdminPanelViewModel GetUsersByFilter(string username = "",int pageId = 1);
    }
}
