using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Users
{
    public class UserNotification
    {
        [Key]
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "عنوان پیغام را وارد کنید")]
        public string Title { get; set; }
        [Required(ErrorMessage = "متن پیغام را وارد کنید")]
        public string Text { get; set; }
        [Required]
        public bool IsSee { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }


        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }

        #endregion
    }
}