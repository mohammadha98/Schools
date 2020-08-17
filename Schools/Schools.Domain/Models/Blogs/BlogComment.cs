using Schools.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Schools.Domain.Models.Blogs
{
    public class BlogComment
    {
        public BlogComment()
        {

        }
        [Key]
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }

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
        public bool IsDelete { get; set; }

        #region Relation
        public Blog Blog { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public List<AnswersComment> answersComments { get; set; }
        #endregion
    }
}
