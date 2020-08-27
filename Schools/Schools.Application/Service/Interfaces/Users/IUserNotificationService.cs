using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.Application.Service.Interfaces.Users
{
    public interface IUserNotificationService
    {
        NotificationsViewModel GetUserNotifications(int pageId, int take, int userId);
    }
}