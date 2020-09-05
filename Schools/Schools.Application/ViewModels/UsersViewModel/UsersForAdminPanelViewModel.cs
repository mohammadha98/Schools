using Microsoft.AspNetCore.Http;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Schools.Domain.Models.Users.Tickets;

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
        
    }
    public class GetTicketsViewModel
    {
        public List<UserTicket> UserTickets { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int? CategoryId { get; set; }
        public int? PriorityId { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}
