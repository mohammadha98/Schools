using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Schools
{
    public class SchoolRules
    {
        [Key]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "متن قوانین را وارد کنید")]
        public string RuleTitle { get; set; }
    }
}