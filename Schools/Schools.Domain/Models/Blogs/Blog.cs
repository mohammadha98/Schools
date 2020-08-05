using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace Schools.Domain.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        [Display(Name ="گروه دسته بندی")]
        public int GroupID { get; set; }

        [Display(Name = "عنوان بلاگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string BlogText { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name ="بازدید")]
        public int BlogVisit { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }

        public BlogGroup BlogGroup { get; set; }
        public List<BlogComment> BlogComment { get; set; }
    }
}
