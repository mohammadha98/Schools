using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Users.Tickets;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Tickets.Categories
{
    [PermissionsChecker(23)]
    public class IndexModel : PageModel
    {
        private IUserTicketRepository _ticket;

        public IndexModel(IUserTicketRepository ticket)
        {
            _ticket = ticket;
        }
        public List<TicketCategory> TicketCategories { get; set; }
        public void OnGet()
        {
            TicketCategories = _ticket.GetTicketCategories();
        }
    }
}
