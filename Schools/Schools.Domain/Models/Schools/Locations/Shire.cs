using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Schools.Locations
{
    public class Shire
    {
        [Key]
        public int ShireId { get; set; }
        [Required(ErrorMessage = "لطفا نام استان را وارد کنید")]
        public string ShireTitle { get; set; }
        public bool IsDelete { get; set; }


        #region Relations
        public List<School> Schools { get; set; }
        public List<City> Cities { get; set; }
        #endregion
    }
}