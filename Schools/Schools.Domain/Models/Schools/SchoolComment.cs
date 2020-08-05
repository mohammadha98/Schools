using System;
using System.Collections.Generic;

namespace Schools.Domain.Models.Schools
{
    public class SchoolComment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public int? Answer { get; set; }
        public bool IsDelete { get; set; }

        #region Relations

        public List<SchoolComment> SchoolComments { get; set; }

        #endregion
    }
}