using System.Collections.Generic;

namespace Schools.Application.ViewModels.BlogsViewModels
{
    public class BlogCategoryViewModel
    {
        public List<BlogViewModel> Blogs { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int? TypeId { get; set; }
        public string GroupTitle { get; set; }
        public string Search { get; set; }
    }
}