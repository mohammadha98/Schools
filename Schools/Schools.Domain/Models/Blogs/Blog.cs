using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text;

namespace Schools.Domain.Models.Blogs
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Display(Name ="دسته بندی")]
        public int GroupId { get; set; }

        [Display(Name = "نوع بلاگ")]
        public int TypeId { get; set; }

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

        [Display(Name = "تاریخ ساخت")]
        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }


        #region Relation
        [ForeignKey("GroupId")]
        public BlogGroup BlogGroup { get; set; }
        [ForeignKey("TypeId")]
        public BlogType BlogType { get; set; }
        public List<BlogComment> BlogComment { get; set; }
        
        #endregion
    }
}
