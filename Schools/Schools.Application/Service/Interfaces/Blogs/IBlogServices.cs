using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Domain.Models.Blogs;

namespace Schools.Application.Service.Interfaces.Blogs
{
    public interface IBlogServices
    {
        bool AddBlog(Blog blog,IFormFile image);
        bool EditBlog(Blog blog,IFormFile image);
        BlogCategoryViewModel GetBlogsByFilter(int pageId, int take, string search, int? typeId, string groupTitle);
        List<BlogViewModel> GetLastBlogs(int take);
        void AddVisitForBlog(Blog blog);
    }
}
