using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools
{
    public class SchoolVisit
    {
        [Required]
        public int VisitId { get; set; }
        public int? UserId { get; set; }
        public string UserIp { get; set; }
        public int SchoolId { get; set; }

        #region Relations

        [ForeignKey("SchoolId")]
        public School School { get; set; }

        #endregion

    }
}