using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools
{
    public class SchoolGallery
    {
        [Key]
        public int GalleryId { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public string ImageName { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        #region Relations
        [ForeignKey("SchoolId")]
        public School School { get; set; }

        #endregion
    }
}