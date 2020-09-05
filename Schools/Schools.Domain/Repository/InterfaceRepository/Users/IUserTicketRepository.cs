using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Users;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserTicketRepository
    {
        IQueryable<UserTicket> GetUserTickets(int userId);
        IQueryable<UserTicket> GetAllTickets();
        void AddTicket(UserTicket ticket);
        void EditTicket(UserTicket ticket);
        UserTicket GetUserTicket(int ticketId);
        void AddTicketCategory(TicketCategory category);
        void EditTicketCategory(TicketCategory category);
        TicketCategory GetTicketCategory(int categoryId);

        List<TicketCategory> GetTicketCategories();
        List<TicketPriority> GetTicketPriorities();
        void AddMessageToTicket(TicketMessage message);
    }
}