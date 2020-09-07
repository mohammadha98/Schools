using System;

namespace Schools.Application.ViewModels.BlogsViewModels
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string GroupTitle { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImageName { get; set; }
        public string BlogType { get; set; }
        public string ShortLink { get; set; }
    }
}