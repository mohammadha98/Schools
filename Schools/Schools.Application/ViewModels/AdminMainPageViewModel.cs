using System.Collections.Generic;
using Schools.Domain.Models;
using Schools.Domain.Models.ContactUs;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.Application.ViewModels
{
    public class AdminMainPageViewModel
    {
        public int UsersCount { get; set; }
        public int ActiveSchoolsCount { get; set; }
        public int DeActiveSchoolsCount { get; set; }
        public int RequestCount { get; set; }
        public List<SchoolRequest> SchoolRequests { get; set; }
        public List<ContactUsForm> NewMessages { get; set; }
        public List<UserTicket> NewTickets { get; set; }
        public List<School> NewRequests { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<School> TopRateSchools { get; set; }

    }
}