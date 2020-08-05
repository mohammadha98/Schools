using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools.Teachers
{
    public class TeacherRate
    {
        [Key]
        public int RateId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public float Rate { get; set; }

        public bool IsDelete { get; set; }


        #region Relations
        [ForeignKey("TeacherId")]
        public SchoolTeacher SchoolTeacher { get; set; }
        #endregion
    }
}