using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Pages.SchoolPanel
{
    [PermissionsChecker(3)]
    public class NotificationsModel : PageModel
    {
        private IUserNotificationService _notification;
        private ISchoolRepository _school;

        public NotificationsModel(IUserNotificationService notification, ISchoolRepository school)
        {
            _notification = notification;
            _school = school;
        }
     
        public School School { get; set; }
        public NotificationsViewModel Notifications { get; set; }
        public void OnGet(int pageId=1)
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            Notifications = _notification.GetUserNotifications(pageId, 10, User.GetUserId());
            if (School == null)
            {
                Response.Redirect("/");
            }
        }

    }
}
