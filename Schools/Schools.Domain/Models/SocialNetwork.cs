using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models
{
    public class SocialNetwork
    {
        [Key]
        public int SW_Id { get; set; }
        [Required(ErrorMessage = "نام شبکه اجتماعی را وارد کنید")]
        public string NetworkName { get; set; }
        [Required(ErrorMessage = "آدرس  صفحه خود در این شبکه را وارد کنید")]
        public string NetWorkLink { get; set; }

    }
}