using System.Linq;
using Schools.Domain.Models.Users;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserNotificationRepository
    {
        IQueryable<UserNotification> GetUserNotifications(int userId);
        void AddNotification(UserNotification notification);
        void DeleteUserNotification(UserNotification notification);
        UserNotification GetNotificationById(int notificationId);
        void UpdateNotification(UserNotification notification);

    }
}