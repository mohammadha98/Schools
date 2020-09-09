using System.Linq;
using Schools.Application.Service.Interfaces;
using Schools.Application.ViewModels;
using Schools.Domain.Repository.InterfaceRepository;
using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.Application.Service.Services
{
    public class AdminMainPageService:IAdminMainPageService
    {
        private ISchoolRepository _school;
        private IUserRepository _user;
        private IUserTicketRepository _ticket;
        private IContactUsFormRepository _contactUs;
        private ISchoolRequestRepository _request;
        private ISocialNetworkRepository _network;

        public AdminMainPageService(ISchoolRepository school, IUserRepository user, IUserTicketRepository ticket, IContactUsFormRepository contactUs, ISchoolRequestRepository request, ISocialNetworkRepository network)
        {
            _school = school;
            _user = user;
            _ticket = ticket;
            _contactUs = contactUs;
            _request = request;
            _network = network;
        }
        public AdminMainPageViewModel GetDataForMainPage()
        {
            var schools = _school.GetAllSchools();
            var users = _user.GetUsers();
            var tickets = _ticket.GetAllTickets();
            var requests = _request.GetAllRequest();
            var messages = _contactUs.GetContactUses();

            var mainPageModel=new AdminMainPageViewModel()
            {
                ActiveSchoolsCount = schools.Count(s=>s.IsActive),
                DeActiveSchoolsCount = schools.Count(s=>!s.IsActive),
                RequestCount = requests.Count(r=>!r.IsAccept),
                UsersCount = users.Count(),
                NewMessages = messages.Where(m=>m.IsPosted==false).ToList(),
                SchoolRequests = requests.Where(r=>!r.IsAccept).ToList(),
                NewTickets = tickets.Where(t=>t.IsOpen).ToList(),
                NewRequests = schools.Where(r=>r.SchoolGalleries.Any(g=>!g.IsActive) || r.SchoolTeachers.Any(t=>!t.IsActive) || r.SchoolCourses.Any(c=>!c.IsActive)).ToList(),
                SocialNetworks = _network.GetAllSocialNetworks(),
                TopRateSchools = schools.OrderByDescending(s=>s.SchoolRates.Sum(r=>r.Rate)/s.SchoolRates.Count).Take(8).ToList()
            };
            return mainPageModel;
        }
    }
}