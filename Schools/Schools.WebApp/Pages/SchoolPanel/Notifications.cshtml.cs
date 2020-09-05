using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.WebApp.Pages.SchoolPanel
{
    public class NotificationsModel : PageModel
    {
        private IUserNotificationService _notification;

        public NotificationsModel(IUserNotificationService notification)
        {
            _notification = notification;
        }
        public NotificationsViewModel Notifications { get; set; }
        public void OnGet(int pageId=1)
        {
            Notifications = _notification.GetUserNotifications(pageId, 10, User.GetUserId());
        }

    }
}
