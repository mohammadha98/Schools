using System;
using System.Collections.Generic;
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
        public int TypeId { get; set; }
        public string TypeTitle { get; set; }

        #region navigationProperty
        public List<Blog> Blogs { get; set; }
        #endregion
    }
}
