using Schools.Domain.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Domain.Repository.InterfaceRepository.BlogRepositories
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAllBlogs();
        Blog GetBlogById(int blogId);
        void InsertBlog(Blog blog);
        void UpdateBlog(Blog blog);
        void Save();
    }
}
