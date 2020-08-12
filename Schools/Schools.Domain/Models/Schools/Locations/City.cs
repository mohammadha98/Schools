using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools.Locations
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public int ShireId { get; set; }
        [Required]
        public string CityTitle { get; set; }
        [Required]
        public bool IsDelete { get; set; }

        #region Relations
        [ForeignKey("ShireId")]
        public Shire Shire { get; set; }
        public List<School> Schools { get; set; }
        #endregion
    }
}