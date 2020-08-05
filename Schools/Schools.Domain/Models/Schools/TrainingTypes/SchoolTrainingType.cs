using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools.TrainingTypes
{
    public class SchoolTrainingType
    {
        [Key]
        public int STT_ID { get; set; }
        public int SchoolId { get; set; }
        public int TypeId { get; set; }

        #region Relations
        [ForeignKey("SchoolId")]
        public School School { get; set; }
        [ForeignKey("TypeId")]
        public TrainingType TrainingType { get; set; }
        #endregion
    }
}