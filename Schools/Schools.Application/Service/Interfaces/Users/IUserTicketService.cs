
using System.Collections.Generic;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.Application.Service.Interfaces.Users
{
   public interface IUserTicketService
    {
        TicketsViewModel GetUserTicketsWithFilter(int userId,int pageId,int take, string startDate, string endDate);
        UserTicket GetTicketById(int ticketId);
        int AddTicket(UserTicket ticket);
        List<TicketCategory> GetTicketCategories();
        List<TicketPriority> GetTicketPriority();
        void AddTicketToMessage(int ticketId, string message,int userId);
    }
}
