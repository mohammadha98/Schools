using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools
{
    public class SchoolCourse
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseTitle { get; set; }
        [Required]
        public string CourseDescription { get; set; }
        [Required]
        public int SchoolId { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }

        #region Relations

        [ForeignKey("SchoolId")]
        public School School { get; set; }

        #endregion
    }
}