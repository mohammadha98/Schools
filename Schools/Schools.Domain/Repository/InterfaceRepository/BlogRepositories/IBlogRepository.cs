using Schools.Domain.Models.Blogs;
using System.Linq;

namespace Schools.Domain.Repository.InterfaceRepository.BlogRepositories
{
    public interface IBlogRepository
    {
      

        IQueryable<Blog> GetAllBlogs();
        Blog GetBlogById(int blogId);
        Blog GetBlog(int blogId);
        Blog GetBlog(string shortLink);
        void InsertBlog(Blog blog);
        void UpdateBlog(Blog blog);
    

    }
}
