using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools
{
    public class SchoolRate
    {
        [Key]
        public int RateId { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public float Rate { get; set; }
        public bool IsDelete { get; set; }


        #region Relations
        [ForeignKey("SchoolId")]
        public School School { get; set; }

        #endregion
    }
}