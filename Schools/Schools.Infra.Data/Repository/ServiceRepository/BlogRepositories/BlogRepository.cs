using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private SchoolsDbContext _context;
        public BlogRepository(SchoolsDbContext context)
        {
            _context = context;
        }

        public IQueryable<Blog> GetAllBlogs()
        {
            return _context.Blogs.Include(b => b.BlogGroup).Include(b => b.BlogType);
        }

        public Blog GetBlogById(int blogId)
        {
            return _context.Blogs.Include(b => b.BlogGroup).Include(b => b.BlogType).SingleOrDefault(b => b.BlogId == blogId);
        }

        public Blog GetBlog(int blogId)
        {
            return _context.Blogs.Find(blogId);
        }

        public Blog GetBlog(string shortLink)
        {
            return _context.Blogs.SingleOrDefault(b => b.ShortLink == shortLink);
        }


        public void InsertBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }
        public void UpdateBlog(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }
    }
}
