using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.UserPanel
{
    //2 = دانشجو
    [PermissionsChecker(2)]
    public class NotificationsModel : PageModel
    {
        private IUserNotificationService _notification;
        private IUserNotificationRepository _repository;

        public NotificationsModel(IUserNotificationService notification, IUserNotificationRepository repository)
        {
            _notification = notification;
            _repository = repository;
        }

        public NotificationsViewModel Notifications { get; set; }
        public void OnGet(int pageId = 1)
        {
            Notifications = _notification.GetUserNotifications(pageId, 10, User.GetUserId());
        }

        public IActionResult OnGetDeleteNotification(int notificationId)
        {
            var notification = _repository.GetNotificationById(notificationId);

            if (notification == null) return Content("Error");
            if (notification.UserId != User.GetUserId()) return Content("Error");

            _repository.DeleteUserNotification(notification);
            return Content("Deleted");

        }
        public IActionResult OnGetSeeNotification(int id)
        {
            var notification = _repository.GetNotificationById(id);

            if (notification == null) return Content("Error");
            if (notification.UserId != User.GetUserId()) return Content("Error");

            notification.IsSee = true;
            _repository.UpdateNotification(notification);
            return Content("Success");

        }
    }
}
