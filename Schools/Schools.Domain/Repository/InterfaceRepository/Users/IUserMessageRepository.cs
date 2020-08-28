using System.Linq;
using Schools.Domain.Models.Users.Messages;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserMessageRepository
    {
        IQueryable<UserMessage> GetUserMessages(int userId);
        void AddMessage(UserMessage message);
        void UpdateMessage(UserMessage message);
        void UpdateMessageContent(MessageContent content);
        void SaveChange();
        UserMessage GetUserMessage(int messageId);
        void AddMessageContent(MessageContent content);
    }
}