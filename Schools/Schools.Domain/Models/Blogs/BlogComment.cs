using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schools.Domain.Models
{
    public class BlogComment
    {
        [Key]
        public int CommentID { get; set; }
        public int BlogID { get; set; }

        [Display(Name ="نام و نام خانودگی")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "دیدگاه شما")]
        [Required(ErrorMessage = "لطفا دیدگاهتان را بنویسید")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        [Display(Name = "پاسخ")]
        public int? Answer { get; set; }

        [Display(Name = "کد امنیتی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int SecurityCode { get; set; }

        #region navigationProperty
        public Blog Blog { get; set; }
        #endregion
    }
}
