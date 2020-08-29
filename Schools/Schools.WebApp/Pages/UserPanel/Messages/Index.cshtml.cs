using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users.Messages;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Pages.UserPanel.Messages
{
    public class IndexModel : PageModel
    {
        private IUserMessageService _service;
        private ISchoolRepository _school;

        public IndexModel(IUserMessageService service, ISchoolRepository school)
        {
            _service = service;
            _school = school;
        }

        public MessagesViewModel MessageModel { get; set; }
        public void OnGet(int pageId = 1, string startDate = "", string endDate = "")
        {
            MessageModel = _service.GetUserMessages(pageId, 10, User.GetUserId());
        }

        public IActionResult OnGetSendMessage(string title,string text, int schoolId)
        {
            var school = _school.GetSchoolBySchoolId(schoolId);
            if (school == null)
            {
                return BadRequest();
            }
            var message=new UserMessage()
            {
                ReceiverId = school.SchoolManager,
                SenderId = User.GetUserId(),
                SenderText = text,
                MessageTitle = title,
                CreateDate = DateTime.Now,
                IsDelete = false
            };
            _service.AddMessage(message);
            return Content("Success");
        }

    }
}
