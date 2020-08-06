using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Schools.Domain.Models.Users;

namespace Schools.Domain.Models.Schools
{
    public class SchoolVisit
    {
        [Key]
        public int VisitId { get; set; }
        public int? UserId { get; set; }
        public string UserIp { get; set; }
        public int SchoolId { get; set; }
        public bool IsDelete { get; set; }
        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("SchoolId")]
        public School School { get; set; }

        #endregion

    }
}