using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Schools.Domain.Models.Users;

namespace Schools.Domain.Models.Schools.Teachers
{
    public class SchoolTeacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public string Bio { get; set; }

        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }

        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; }

        public List<TeacherRate> TeacherRates { get; set; }
        #endregion
    }
}