using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities;
using Schools.Domain.Models.Users;
using Schools.Domain.Models.Users.Tickets;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Tickets
{
    public class ShowModel : PageModel
    {
        private IUserTicketRepository _ticket;
        private IUserNotificationRepository _notification;

        public ShowModel(IUserTicketRepository ticket, IUserNotificationRepository notification)
        {
            _ticket = ticket;
            _notification = notification;
        }
        public UserTicket UserTicket { get; set; }
        public void OnGet(int ticketId)
        {
            UserTicket = _ticket.GetUserTicket(ticketId);
            if (UserTicket==null)
            {
                Response.Redirect("/ManagementPanel/Tickets");
            }
        }

        public IActionResult OnPost(string message, int ticketId)
        {
            var ticket = _ticket.GetUserTicket(ticketId);

            if (string.IsNullOrEmpty(message))
            {
                UserTicket = ticket;
                return Page();
            }
            if (ticket == null)
            {
                return Redirect("/ManagementPanel/Tickets");
            }
            //Add Message
            var messageModel=new TicketMessage()
            {
                IsDelete = false,
                IsSeen = false,
                MessageText = message,
                SendDate = DateTime.Now,
                TicketId = ticketId,
                UserId = User.GetUserId()
            };
            _ticket.AddMessageToTicket(messageModel);

            //Add Notification
            var notification=new UserNotification()
            {
                IsDelete = false,
                CreateDate = DateTime.Now,
                Text = $"شما یک پیام جدید در تیکت شماره <a href='/UserPanel/tickets/show/{ticketId}'>{ticketId}</a> دارید",
                IsSee = false,
                Title = "تیکت جدید",
                UserId = ticket.BuilderId
            };
            _notification.AddNotification(notification);
            return Redirect("/ManagementPanel/Tickets/Show/" + ticketId);
        }

        public IActionResult OnGetCloseTicket(int ticketId)
        {
            var ticket = _ticket.GetUserTicket(ticketId);
           
            if (ticket==null)
            {
                return Content("Error");
            }

            ticket.IsOpen = false;
            _ticket.EditTicket(ticket);
            return Content("Success");
        }
    }
}
