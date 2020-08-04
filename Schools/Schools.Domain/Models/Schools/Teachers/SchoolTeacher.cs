using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        #region Relations

        [ForeignKey("SchoolId")]
        public School School { get; set; }

        #endregion
    }
}