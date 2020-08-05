using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Schools.TrainingTypes
{
    public class TrainingType
    {
        [Key]
        public int TypeId { get; set; }
        [Required(ErrorMessage = "عنوان را وارد کنید")]
        public string TypeTitle { get; set; }
        public bool IsDelete { get; set; }


        #region Relations

        public List<SchoolTrainingType> SchoolTrainingTypes { get; set; }

        #endregion
    }
}