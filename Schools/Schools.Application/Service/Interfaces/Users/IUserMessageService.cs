using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users.Messages;

namespace Schools.Application.Service.Interfaces.Users
{
    public interface IUserMessageService
    {
        MessagesViewModel GetUserMessages(int pageId, int take, int userId,string startDate,string endDate);
        void SeenMessages(int messageId,int userId);
        void AddMessage(UserMessage message);
    }
}