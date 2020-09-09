using System.Collections.Generic;
using System.Linq;
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
        List<TicketPriority> GetTicketPriorities();
        void SaveChanges();
        #region TicketCategory

        void AddTicketCategory(TicketCategory category);
        void EditTicketCategory(TicketCategory category);
        TicketCategory GetTicketCategory(int categoryId);
        List<TicketCategory> GetTicketCategories();

        #endregion

        #region TicketMessages

        void AddMessageToTicket(TicketMessage message);
        void EditMessage(TicketMessage message);

        #endregion
    }
}