using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Schools.Domain.Models.Users;
using Schools.Domain.Models.Users.Messages;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.Application.ViewModels.UsersViewModel
{
    public class ChangePasswordViewModel
    {
        public int UserId { get; set; }
        [Display(Name ="رمز عبور فعلی")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        public string CurrentPassword { get; set; }

        [Display(Name = "رمز عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        [MinLength(6,ErrorMessage = "رمز عبور باید بیشتر از 6 کاراکتر باشد")]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        [Compare("NewPassword", ErrorMessage = "کلمه های عبور یکسان نیستند")]
        public string ReNewPassword { get; set; }
    }

    public class EditUserInfoViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "نام را وارد کنید")]
        public string Name { get; set; }
        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        public string Family { get; set; }
        [Display(Name = "شماره همراه")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} عدد باشد .")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند کمتر از {1} عدد باشد .")]
        public string Phone { get; set; }
        [Display(Name = "شماره ثابت")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} عدد باشد .")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند کمتر از {1} عدد باشد .")]
        public string TelNumber { get; set; }
        [Display(Name = "توضیحات")]
        public string AboutMe { get; set; }
        [Display(Name = "کد ملی")]
        [MaxLength(10, ErrorMessage = "کدملی نامعتبر است .")]
        [MinLength(10, ErrorMessage = "کدملی نامعتبر است .")]
        public string NationalCode { get; set; }
    }
    public class TicketsViewModel
    {
        public List<UserTicket> UserTickets { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
    public class MessagesViewModel
    {
        public List<UserMessage> UserMessages { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
    public class NotificationsViewModel
    {
        public List<UserNotification> UserNotifications { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}
