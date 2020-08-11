using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.ViewModels.BlogsViewModels
{
    public class BlogsViewModels
    {
        public int BlogId { get; set; }
        public int TypeId { get; set; }
        public string BlogType { get; set; }
        public int GroupId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
