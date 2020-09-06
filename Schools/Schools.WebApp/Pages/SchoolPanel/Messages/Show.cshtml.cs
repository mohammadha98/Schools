using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Users.Messages;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.SchoolPanel.Messages
{
    [PermissionsChecker(3)]

    public class ShowModel : PageModel
    {
        private IUserMessageRepository _message;
        private IUserMessageService _service;

        public ShowModel(IUserMessageRepository message, IUserMessageService service)
        {
            _message = message;
            _service = service;
        }
        public UserMessage UserMessage { get; set; }
        public void OnGet(int messageId)
        {
            UserMessage = _message.GetUserMessage(messageId);
            var userId = User.GetUserId();

            if (UserMessage != null)
            {
                if (UserMessage.SenderId != userId && UserMessage.ReceiverId != userId)
                {
                    Response.Redirect("/SchoolPanel/Messages");
                }
                else
                {
                    _service.SeenMessages(messageId, userId);
                }
            }
            else
            {
                Response.Redirect("/SchoolPanel/Messages");

            }
        }

        public IActionResult OnPost(int messageId, string messageText)
        {
            if (string.IsNullOrEmpty(messageText))
            {
                UserMessage = _message.GetUserMessage(messageId);
                return Page();
            }
            var userId = User.GetUserId();
            var message = _message.GetUserMessage(messageId);
            if (message == null)
            {
                return Redirect("/SchoolPanel/Messages");
            }

            if (message.SenderId != userId && message.ReceiverId != userId)
            {
                return Redirect("/SchoolPanel/Messages");
            }
            var content = new MessageContent()
            {
                IsSeen = false,
                IsDelete = false,
                MessageId = messageId,
                SendDate = DateTime.Now,
                Text = messageText,
                UserId = userId
            };
            _message.AddMessageContent(content);
            return Redirect("/SchoolPanel/Messages/Show/" + messageId);
        }
    }
}
