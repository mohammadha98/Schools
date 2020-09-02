using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.WebApp.Pages.SchoolPanel.Tickets
{
    public class ShowModel : PageModel
    {
        private IUserTicketService _service;

        public ShowModel(IUserTicketService service)
        {
            _service = service;
        }
        public UserTicket UserTicket { get; set; }
        public void OnGet(int ticketId)
        {
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
