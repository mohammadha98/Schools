using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.WebApp.Pages.UserPanel.Tickets
{
    //12 = ثبت تیکت
    [PermissionsChecker(12)]
    public class AddModel : PageModel
    {
        private IUserTicketService _service;

        public AddModel(IUserTicketService service)
        {
            _service = service;
        }
        [BindProperty]
        public UserTicket UserTicket { get; set; }
        public void OnGet()
        {
            ViewData["Categories"] = _service.GetTicketCategories();
            ViewData["Priorities"] = _service.GetTicketPriority();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = _service.GetTicketCategories();
                ViewData["Priorities"] = _service.GetTicketPriority();
                return Page();
            }

            UserTicket.BuilderId = User.GetUserId();
           var ticketId=_service.AddTicket(UserTicket);
            return Redirect("/UserPanel/Tickets/Show/"+ticketId);
        }
    }
}
