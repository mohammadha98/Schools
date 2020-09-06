using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Blogs
{
    public class BlogGroup
    {
        [Key]
        public int GroupId { get; set; }
        [Display(Name ="عنوان گروه")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string GroupName { get; set; }
        public bool IsDelete { get; set; }

        #region Relation
        public List<Blog> Blog { get; set; }
        #endregion
    }
}
