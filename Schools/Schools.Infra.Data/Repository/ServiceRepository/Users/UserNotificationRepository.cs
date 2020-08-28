using System.Linq;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Users
{
    public class UserNotificationRepository:IUserNotificationRepository
    {
        private SchoolsDbContext _db;

        public UserNotificationRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public IQueryable<UserNotification> GetUserNotifications(int userId)
        {
            return _db.UserNotifications.Where(n => n.UserId == userId);
        }

        public void AddNotification(UserNotification notification)
        {
            _db.UserNotifications.Add(notification);
            _db.SaveChanges();
        }

        public void DeleteUserNotification(UserNotification notification)
        {
          
            notification.IsDelete = true;
            _db.UserNotifications.Update(notification);
            _db.SaveChanges();
        }

        public UserNotification GetNotificationById(int notificationId)
        {
            return _db.UserNotifications.SingleOrDefault(n => n.NotificationId == notificationId);
        }

        public void UpdateNotification(UserNotification notification)
        {
            _db.UserNotifications.Update(notification);
            _db.SaveChanges();
        }
    }
}