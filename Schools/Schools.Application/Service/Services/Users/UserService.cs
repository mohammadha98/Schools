using Microsoft.EntityFrameworkCore.Internal;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Repository.InterfaceRepository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Schools.Application.Service.Services.Users
{
    public class UserService : IUserService
    {
        private IUserRepository _IuserRepository;
        public UserService(IUserRepository userRepository)
        {
            _IuserRepository = userRepository;
        }

        public UsersForAdminPanelViewModel GetUsersByFilter(string username = "", int pageId = 1)
        {
            var list = _IuserRepository.GetUsers();

            if (!string.IsNullOrEmpty(username))
                list = list.Where(u => u.UserName.Contains(username));

            int take = 15;
            int skip = (pageId - 1) * take;

            UsersForAdminPanelViewModel result = new UsersForAdminPanelViewModel();
            result.CurrentPage = pageId;
            result.PageCount = list.Count() / take;
            result.GetUsers = list.OrderByDescending(u => u.RegisterDate).Take(take).Skip(skip).ToList();

            return result;
        }
    }
}
