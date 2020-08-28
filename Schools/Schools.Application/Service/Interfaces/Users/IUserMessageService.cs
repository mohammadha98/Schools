using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.Application.Service.Interfaces.Users
{
    public interface IUserMessageService
    {
        MessagesViewModel GetUserMessages(int pageId, int take, int userId);
        void SeenMessages(int messageId,int userId);
    }
}