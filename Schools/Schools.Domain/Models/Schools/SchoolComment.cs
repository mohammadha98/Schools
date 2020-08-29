using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Schools.Domain.Models.Users;

namespace Schools.Domain.Models.Schools
{
    public class SchoolComment
    {
        [Key]
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int SchoolId { get; set; }
        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public int? Answer { get; set; }
        public bool IsDelete { get; set; }

        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("SchoolId")]
        public School School { get; set; }
        [ForeignKey("Answer")]
        public List<SchoolComment> Answers { get; set; }

        #endregion
    }
}