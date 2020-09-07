using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Pages.SchoolPanel.Tickets
{
    [PermissionsChecker(13)]

    public class IndexModel : PageModel
    {
        private IUserTicketService _service;
        private ISchoolRepository _school;

        public IndexModel(IUserTicketService service, ISchoolRepository school)
        {
            _service = service;
            _school = school;
        }
        public IndexModel(IUserTicketService service)
        {
            _service = service;
        }

        public School School { get; set; }
        public TicketsViewModel TicketsModel { get; set; }
        public void OnGet(int pageId = 1, string startDate = "", string endDate = "")
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School == null)
            {
                Response.Redirect("/");
            }
            TicketsModel = _service.GetUserTicketsWithFilter(User.GetUserId(), pageId, 5, startDate, endDate);
        }
    }
}
