using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.SchoolsViewModels.SchoolRequest;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Requests
{
    [PermissionsChecker(29)]
    public class ShowModel : PageModel
    {
        private ISchoolRequestService _service;
        private IUserNotificationRepository _notification;
        private ISchoolService _school;

        public ShowModel(ISchoolRequestService service, IUserNotificationRepository notification, ISchoolService school)
        {
            _service = service;
            _notification = notification;
            _school = school;
        }


        [BindProperty]
        public AcceptOrRejectRequestViewModel SubmitModel { get; set; }
        public SchoolRequest SchoolRequest { get; set; }
        public void OnGet(int requestId)
        {
            SchoolRequest = _service.GetSchoolRequest(requestId);
            if (SchoolRequest == null)
            {

                Response.Redirect("/managementPanel/Schools/Requests");
            }
        }

        public IActionResult OnPost(int requestId)
        {
            var request = _service.GetSchoolRequest(requestId);
            if (request == null) return Redirect("/managementPanel/Schools/requests");


            //دلیل رد را برای کاربر ارسال میکنیم و بعد درخواست رو حذف میکنیم
            var notification = new UserNotification()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsSee = false,
                Text = SubmitModel.RejectText,
                Title = "عدم تایید آموزشگاه",
                UserId = request.UserId
            };

            if (SubmitModel.IsAccept)
            {
                var res = _school.AddNewSchool(request, SubmitModel);
                if (res)
                {
                    _service.AcceptRequest(request,Request.Host.ToString());
                    notification.Text =
                        "آموزشگاه شما تایید شده برای ثبت اساتید آموزشگاه به <a href='/SchoolPanel/Teachers'>این لینک</a> مراجعه کنید";
                    notification.Title = "تایید آموزشگاه";
                    _notification.AddNotification(notification);
                    return RedirectToPage("Index");
                }

                SchoolRequest = request;
                return Page();
            }

            _notification.AddNotification(notification);
            _service.RejectRequest(request,SubmitModel.RejectText);
            return RedirectToPage("Index");
        }
    }
}
