using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users.Messages;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.Domain.Models.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string Family { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string UserName { get; set; }

        [Display(Name ="رمز عبور")]  
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

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



        #region Relations

        public  List<UserRole> UserRoles { get; set; }
        public List<UserTicket> UserTickets { get; set; }
        public List<UserNotification> UserNotifications { get; set; }
        [InverseProperty("Sender")]
        public List<UserMessage> SenderMessages { get; set; }
        [InverseProperty("Receiver")]
        public List<UserMessage> ReceiverMessages { get; set; }

        public List<SchoolLike> SchoolLikes { get; set; }
        public List<SchoolRate> SchoolRates { get; set; }
        #endregion
    }
}
