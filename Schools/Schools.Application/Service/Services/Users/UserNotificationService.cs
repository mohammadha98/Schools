using System;
using System.Linq;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.Application.Service.Services.Users
{
    public class UserNotificationService : IUserNotificationService
    {
        private IUserNotificationRepository _notification;

        public UserNotificationService(IUserNotificationRepository notification)
        {
            _notification = notification;
        }

        public NotificationsViewModel GetUserNotifications(int pageId, int take, int userId)
        {
            var result = _notification.GetUserNotifications(userId).OrderByDescending(n=>n.CreateDate);
            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);
            var notificationsModel = new NotificationsViewModel()
            {
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                UserNotifications = result.Skip(skip).Take(take).ToList()
            };
            return notificationsModel;
        }

    }
}