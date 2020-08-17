using Schools.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Schools.Domain.Models.Blogs
{
    public class AnswersComment
    {
        [Key]
        public int AnswerId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string AnswerText { get; set; }
        public bool IsDelete { get; set; }

        #region Relation
        [ForeignKey("CommentId")]
        public BlogComment blogComment { get; set; }

        [ForeignKey("CommentId")]
        public User User { get; set; }
        #endregion
    }
}
