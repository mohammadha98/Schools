using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Internal;
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

        public IActionResult OnGetDelete(int categoryId)
        {
            var category = _ticket.GetTicketCategory(categoryId);
            if (category==null)
            {
                return Content("NotFound");
            }

            if (!category.UserTickets.Any())
            {
                category.IsDelete = true;
                _ticket.EditTicketCategory(category);
                return Content("Deleted");
            }

            return Content("Error");
        }
    }
}
