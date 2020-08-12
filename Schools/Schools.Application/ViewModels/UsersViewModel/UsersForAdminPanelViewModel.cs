using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.ViewModels.UsersViewModel
{
    public class UsersForAdminPanelViewModel
    {
        public List<User> GetUsers { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }

    }

    public class UserInfoViewModel
    {
        public User User { get; set; }
        public List<string> userRoles { get; set; }
        public List<School> Schools { get; set; }
    }
}
