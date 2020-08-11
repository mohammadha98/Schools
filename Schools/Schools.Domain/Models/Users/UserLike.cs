using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Schools.Domain.Models.Schools;

namespace Schools.Domain.Models.Users
{
    public class UserLike
    {
        [Key]
        public int UserLikeId { get; set; }

        [Required]
        public int SchoolId { get; set; }

        [Required]
        public int UserId { get; set; }

        public bool IsDelete { get; set; }

        #region relations

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("SchoolId")]
        public School School { get; set; }

        #endregion
    }
}