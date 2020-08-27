using System;
using System.Linq;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.Application.Service.Services.Users
{
    public class UserMessageService:IUserMessageService
    {
        private IUserMessageRepository _message;

        public UserMessageService(IUserMessageRepository message)
        {
            _message = message;
        }

        public MessagesViewModel GetUserMessages(int pageId, int take, int userId)
        {
            var result = _message.GetUserMessages(userId).OrderByDescending(n => n.CreateDate);
            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);
            var messagesModel = new MessagesViewModel()
            {
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                UserMessages = result.Skip(skip).Take(take).ToList()
            };
            return messagesModel;
        }

        public void SeenMessages(int messageId,int userId)
        {
            var message = _message.GetUserMessage(messageId);
            foreach (var item in message.MessageContents.Where(c=>c.UserId != userId))
            {
                if (item.IsSeen) continue;

                item.IsSeen = true;
                _message.UpdateMessageContent(item);
            }
            _message.SaveChange();
        }
    }
}