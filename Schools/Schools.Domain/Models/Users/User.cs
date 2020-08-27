using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Models.Users.Messages;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.Domain.Models.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string Family { get; set; }

        [Display(Name = "کد ملی")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string NationalCode { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Display(Name = "شماره ثابت")]
        [MaxLength(11)]
        public string TelNumber { get; set; }

        [Display(Name ="کلمه عبور")]  
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }

        [Display(Name = "کد فعال سازی")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ActiveCode { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "آواتار")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserAvatar { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        public bool IsDelete { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(800, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Description { get; set; }



        #region Relations
        public   List<UserRole> UserRoles { get; set; }
        public  List<UserTicket> UserTickets { get; set; }
        public  List<UserNotification> UserNotifications { get; set; }
        [InverseProperty("Sender")]
        public  List<UserMessage> SenderMessages { get; set; }
        [InverseProperty("Receiver")]
        public  List<UserMessage> ReceiverMessages { get; set; }
        public  List<UserLike> UserLikes { get; set; }
        public  List<SchoolRate> SchoolRates { get; set; }
        public  List<TeacherRate> TeacherRates { get; set; }
        public  List<BlogComment> BlogComments { get; set; }
        #endregion
    }
}
