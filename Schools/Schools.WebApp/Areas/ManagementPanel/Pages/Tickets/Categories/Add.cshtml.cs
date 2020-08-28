using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Users.Tickets;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Tickets.Categories
{
    public class AddModel : PageModel
    {
        private IUserTicketRepository _ticket;

        public AddModel(IUserTicketRepository ticket)
        {
            _ticket = ticket;
        }
        [BindProperty]
        public TicketCategory TicketCategory { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _ticket.AddTicketCategory(TicketCategory);
            return RedirectToPage("Index");
            
        }
    }
}
