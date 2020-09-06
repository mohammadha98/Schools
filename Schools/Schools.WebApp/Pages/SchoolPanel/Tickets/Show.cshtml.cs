using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users.Tickets;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Pages.SchoolPanel.Tickets
{
    [PermissionsChecker(13)]
    public class ShowModel : PageModel
    {
        private IUserTicketService _service;
        private ISchoolRepository _school;

        public ShowModel(IUserTicketService service, ISchoolRepository school)
        {
            _service = service;
            _school = school;
        }
 
        public School School { get; set; }
        public UserTicket UserTicket { get; set; }
        public void OnGet(int ticketId)
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School == null)
            {
                Response.Redirect("/");
            }
            UserTicket = _service.GetTicketById(ticketId);
            if (UserTicket == null)
            {
                Response.Redirect("/SchoolPanel/Tickets");
            }

            if (UserTicket != null && UserTicket.BuilderId != User.GetUserId())
            {
                Response.Redirect("/SchoolPanel/Tickets");
            }
        }

        public IActionResult OnPost(int ticketId, string messageText)
        {
            if (!string.IsNullOrEmpty(messageText))
            {
                var ticket = _service.GetTicketById(ticketId);
                if (ticket.BuilderId != User.GetUserId())
                {
                    return Redirect("/SchoolPanel/Tickets");
                }
                _service.AddTicketToMessage(ticketId, messageText, User.GetUserId());
                return Redirect("/SchoolPanel/Tickets/Show/" + ticketId);
            }
            return Redirect("/SchoolPanel/Tickets/Show/" + ticketId);
        }
    }
}
