using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Users.Messages;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Users
{
    public class UserMessageRepository:IUserMessageRepository
    {
        private SchoolsDbContext _db;

        public UserMessageRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public IQueryable<UserMessage> GetUserMessages(int userId)
        {
            return _db.UserMessages.Include(m=>m.Sender).Include(m=>m.Receiver).Where(m => m.ReceiverId == userId || m.SenderId == userId);
        }

        public void AddMessage(UserMessage message)
        {
            _db.UserMessages.Add(message);
            _db.SaveChanges();
        }

        public void UpdateMessage(UserMessage message)
        {
            _db.UserMessages.Update(message);
            _db.SaveChanges();
        }

        public void UpdateMessageContent(MessageContent content)
        {
            _db.MessageContents.Update(content);
            _db.SaveChanges();
        }

        public void SaveChange()
        {
            _db.SaveChanges();
        }

        public UserMessage GetUserMessage(int messageId)
        {
            return _db.UserMessages.Include(m => m.Sender).Include(m => m.Receiver).Include(m=>m.MessageContents).SingleOrDefault(m => m.Um_Id == messageId);
        }

        public void AddMessageContent(MessageContent content)
        {
            _db.MessageContents.Add(content);
            _db.SaveChanges();
        }
    }
}