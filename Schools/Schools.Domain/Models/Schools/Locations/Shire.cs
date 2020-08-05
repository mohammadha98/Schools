using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Schools.Locations
{
    public class Shire
    {
        [Key]
        public int ShireId { get; set; }
        [Required]
        public string ShireTitle { get; set; }
        [Required]
        public bool IsDelete { get; set; }


        #region Relations
        public List<School> Schools { get; set; }
        public List<City> Cities { get; set; }
        #endregion
    }
}