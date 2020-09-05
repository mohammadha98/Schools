using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Users.Tickets;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Tickets.Categories
{
    public class EditModel : PageModel
    {
        private IUserTicketRepository _ticket;

        public EditModel(IUserTicketRepository ticket)
        {
            _ticket = ticket;
        }
        [BindProperty]
        public TicketCategory TicketCategory { get; set; }
        public void OnGet(int categoryId)
        {
            TicketCategory = _ticket.GetTicketCategory(categoryId);
            if (TicketCategory == null)
            {
                Response.Redirect("/ManagementPanel/Tickets/Categories");
            }
        }

        public IActionResult OnPost(int categoryId)
        {
            TicketCategory.CategoryId = categoryId;
            TicketCategory.IsDelete = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _ticket.EditTicketCategory(TicketCategory);
            return RedirectToPage("Index");
        }
    }
}
