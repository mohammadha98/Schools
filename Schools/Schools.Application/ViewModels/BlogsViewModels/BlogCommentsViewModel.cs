using System.Collections.Generic;
using Schools.Domain.Models.Blogs;

namespace Schools.Application.ViewModels.BlogsViewModels
{
    public class BlogCommentsViewModel
    {
        public List<BlogComment> BlogComments { get; set; }
        public List<BlogComment> AnswerComments { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int CommentsCount { get; set; }
    }
}