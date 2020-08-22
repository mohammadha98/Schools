using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools.Locations
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public string AreaTitle { get; set; }

        public bool IsDelete { get; set; }

        #region Realtions

        public List<School> Schools { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        #endregion
    }
}