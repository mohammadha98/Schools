using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users.Tickets;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Pages.SchoolPanel.Tickets
{
    [PermissionsChecker(12)]

    public class AddModel : PageModel
    {
        private IUserTicketService _service;
        private ISchoolRepository _school;

        public AddModel(IUserTicketService service, ISchoolRepository school)
        {
            _service = service;
            _school = school;
        }

        public School School { get; set; }
        [BindProperty]
        public UserTicket UserTicket { get; set; }
        public void OnGet()
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School==null)
            {
                Response.Redirect("/");
            }
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
            var ticketId = _service.AddTicket(UserTicket);
            return Redirect("/SchoolPanel/Tickets/Show/" + ticketId);
        }
    }
}
