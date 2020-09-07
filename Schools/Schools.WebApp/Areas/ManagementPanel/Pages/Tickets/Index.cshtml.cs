using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Tickets
{
    [PermissionsChecker(21)]
    public class IndexModel : PageModel
    {
        private IUserTicketService _service;

        public IndexModel(IUserTicketService service)
        {
            _service = service;
        }
        public GetTicketsViewModel TicketModel { get; set; }
        public void OnGet(int pageId = 1, string title = "", string status = "", int? categoryId = null, int? priorityId = null)
        {
            TicketModel = _service.GetTicketsForAdmin(pageId, 10, title, status, priorityId, categoryId);
            ViewData["Categories"] = _service.GetTicketCategories();
            ViewData["Priorities"] = _service.GetTicketPriority();
        }
    }
}
