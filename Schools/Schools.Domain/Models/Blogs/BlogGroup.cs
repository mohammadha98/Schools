using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schools.Domain.Models
{
    public class BlogGroup
    {
        [Key]
        public int GroupID { get; set; }
        [Display(Name ="عنوان گروه")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string GroupName { get; set; }

        #region navigation property
        public List<Blog> Blog { get; set; }
        #endregion
    }
}
