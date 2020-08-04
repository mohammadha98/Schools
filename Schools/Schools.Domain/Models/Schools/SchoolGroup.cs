using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schools.Domain.Models.Schools
{
    public class SchoolGroup
    {
        [Key]
        public int GroupId { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "عنوان گروه را وارد کنید")]
        public string GroupTitle { get; set; }
        public int? ParentId { get; set; }
        public bool IsDelete { get; set; }

        #region Relations
        [ForeignKey("ParentId")]
        public List<SchoolGroup> SchoolGroups { get; set; }

        [InverseProperty("SchoolGroup")]
        public List<School> Schools { get; set; }
        [InverseProperty("SchoolSubGroup")]
        public List<School> SchoolsSub { get; set; }
        #endregion
    }
}