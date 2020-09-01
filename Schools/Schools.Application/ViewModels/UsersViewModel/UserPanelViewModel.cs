using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
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
    public class RegisterSchoolViewModel
    {
        [Display(Name = "نام آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SchoolName { get; set; }
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} عدد باشد .")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند کمتر از {1} عدد باشد .")]
        public string CellPhone { get; set; }
        [Display(Name = "شماره ثابت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} عدد باشد .")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند کمتر از {1} عدد باشد .")]
        public string TelePhone { get; set; }
        [Display(Name = "نشانی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "فکس")]
        public string Fax { get; set; }
        public int UserId { get; set; }
        [Display(Name = "استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ShireId { get; set; }
        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CityId { get; set; }
        [Display(Name = "موضوع فعالیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CategoryId { get; set; }
        [Display(Name = "عکس اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public IFormFile SchoolImage { get; set; }
        [Display(Name = "گالری تصاویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public List<IFormFile> Galleries { get; set; }
        [Display(Name = "مدارک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public List<IFormFile> Documents { get; set; }
        [Display(Name = "سال تاسیس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string BuildDate { get; set; }
        [Display(Name = "توضیحات کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }
        public bool IsAcceptRole { get; set; }
        public string[] TrainingTypes { get; set; }

    }
}
