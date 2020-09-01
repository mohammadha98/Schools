using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools
{
    public class RequestGallery
    {
        [Key]
        public int GalleryId { get; set; }
        public int RequestId { get; set; }
        [Required]
        public string ImageName { get; set; }
        public bool IsDelete { get; set; }

        #region Relations
        [ForeignKey("RequestId")]
        public SchoolRequest SchoolRequest { get; set; }

        #endregion
    }
}