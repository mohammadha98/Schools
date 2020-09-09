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

        public IQueryable<UserTicket> GetAllTickets()
        {
            return _context.UserTickets.Include(t=>t.TicketPriority).Include(t => t.TicketCategory).Include(t => t.TicketMessages);

        }

        public void AddTicket(UserTicket ticket)
        {
            _context.UserTickets.Add(ticket);
            _context.SaveChanges();
        }

        public void EditTicket(UserTicket ticket)
        {
            _context.UserTickets.Update(ticket);
            _context.SaveChanges();
        }

        public UserTicket GetUserTicket(int ticketId)
        {
            return _context.UserTickets.Include(t=>t.TicketCategory).Include(t=>t.User).Include(t=>t.TicketMessages).ThenInclude(m=>m.User).SingleOrDefault(t => t.TicketId == ticketId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void AddTicketCategory(TicketCategory category)
        {
            _context.TicketCategories.Add(category);
            _context.SaveChanges();
        }

        public TicketCategory GetTicketCategory(int categoryId)
        {
            return _context.TicketCategories.Include(t=>t.UserTickets).SingleOrDefault(c => c.CategoryId == categoryId);
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

        public void EditMessage(TicketMessage message)
        {
            _context.TicketMessages.Update(message);
        }
    }
}