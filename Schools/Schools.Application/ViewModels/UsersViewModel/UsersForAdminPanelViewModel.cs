using Microsoft.AspNetCore.Http;
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

    public class AddUserViewModel
    {
        public string Name { get; set; }
        public string Family { get; set; }        
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<int> SelectedRoles { get; set; }
        public IFormFile Image { get; set; }
    }
}
