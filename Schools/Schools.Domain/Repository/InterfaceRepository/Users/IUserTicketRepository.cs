using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Users;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserTicketRepository
    {
        IQueryable<UserTicket> GetUserTickets(int userId);
        void AddTicket(UserTicket ticket);
        UserTicket GetUserTicket(int ticketId);
        void AddTicketCategory(TicketCategory category);
        List<TicketCategory> GetTicketCategories();
        List<TicketPriority> GetTicketPriorities();
        void EditTicketCategory(TicketCategory category);
        void AddMessageToTicket(TicketMessage message);
    }
}