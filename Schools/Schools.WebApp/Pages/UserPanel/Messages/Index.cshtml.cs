using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.UserPanel.Messages
{
    public class IndexModel : PageModel
    {
        private IUserMessageService _service;

        public IndexModel(IUserMessageService service)
        {
            _service = service;
        }
        public MessagesViewModel MessageModel { get; set; }
        public void OnGet(int pageId=1,string startDate="",string endDate="")
        {
            MessageModel = _service.GetUserMessages(pageId, 10, User.GetUserId());
        }
        
    }
}
