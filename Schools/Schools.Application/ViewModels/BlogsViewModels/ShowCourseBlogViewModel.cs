using Schools.Domain.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Application.ViewModels.BlogsViewModels
{
    public class ShowCourseBlogViewModel
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public DateTime CreateDate { get; set; }
        public string BlogGroup { get; set; }
        public string BlogType { get; set; }
    }
}
