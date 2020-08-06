using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace Schools.Domain.Models.Blogs
{
    public class BlogType
    {
        public BlogType()
        {
                
        }
        //It is filled with seed Data
        [Key]
        public int TypeId { get; set; }
        public string TypeTitle { get; set; }

        #region Relation
        public List<Blog> Blogs { get; set; }
        #endregion
    }
}
