using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.WebApp.Pages.UserPanel.Tickets
{
    public class IndexModel : PageModel
    {
        private IUserTicketService _service;

        public IndexModel(IUserTicketService service)
        {
            _service = service;
        }

        public TicketsViewModel TicketsModel { get; set; }
        public void OnGet(int pageId=1,string startDate="",string endDate="")
        {
            TicketsModel = _service.GetUserTicketsWithFilter(User.GetUserId(), pageId, 5, startDate, endDate);
        }

    }
}
