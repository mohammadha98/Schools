using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Users.Tickets;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Users
{
    public class UserTicketRepository: IUserTicketRepository
    {
        private SchoolsDbContext _context;

        public UserTicketRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public IQueryable<UserTicket> GetUserTickets(int userId)
        {
            return _context.UserTickets.Include(t=>t.TicketCategory).Include(t=>t.TicketMessages).Where(t => t.BuilderId == userId);
        }

        public void AddTicket(UserTicket ticket)
        {
            _context.UserTickets.Add(ticket);
            _context.SaveChanges();
        }

        public UserTicket GetUserTicket(int ticketId)
        {
            return _context.UserTickets.Include(t=>t.TicketCategory).Include(t=>t.TicketMessages).SingleOrDefault(t => t.TicketId == ticketId);
        }

        public void AddTicketCategory(TicketCategory category)
        {
            _context.TicketCategories.Add(category);
            _context.SaveChanges();
        }

        public List<TicketCategory> GetTicketCategories()
        {
            return _context.TicketCategories.ToList();
        }

        public List<TicketPriority> GetTicketPriorities()
        {
            return _context.TicketPriorities.ToList();
        }

        public void EditTicketCategory(TicketCategory category)
        {
            _context.TicketCategories.Update(category);
            _context.SaveChanges();
        }

        public void AddMessageToTicket(TicketMessage message)
        {
            _context.TicketMessages.Add(message);
            _context.SaveChanges();
        }
    }
}