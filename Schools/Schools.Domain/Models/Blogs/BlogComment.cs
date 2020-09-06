using Schools.Domain.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Blogs
{
    public class BlogComment
    {
        [Key]
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        [Display(Name = "دیدگاه شما")]
        [Required(ErrorMessage = "لطفا دیدگاهتان را بنویسید")]
        [MaxLength(700)]
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public int? Answer { get; set; }

        #region Relation
        public Blog Blog { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion
    }
}
