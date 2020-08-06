using Schools.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Schools.Domain.Models.Schools
{
    public class SchoolLike
    {
        [Key]

        public int SchoolLikeId { get; set; }

        [Required]
        public int SchoolId { get; set; }

        [Required]
        public int UserId { get; set; }

        public bool isLiked { get; set; }
        public bool IsDelete { get; set; }



        #region relations

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("SchoolId")]
        public School School { get; set; }

        #endregion
    }

}
