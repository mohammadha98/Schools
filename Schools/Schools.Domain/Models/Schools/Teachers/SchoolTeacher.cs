using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools.Teachers
{
    public class SchoolTeacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "مدرک تحصیلی را وارد کنید")]
        public string Education { get; set; }
        public int SchoolId { get; set; }
        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        public string Bio { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }

        #region Relations
     

        [ForeignKey("SchoolId")]
        public School School { get; set; }

        public List<TeacherRate> TeacherRates { get; set; }
        #endregion
    }
}