using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schools.Infra.Data.Repository.ServiceRepository.BlogRepositoris
{
    public class BlogRepository : IBlogRepository
    {
        private SchoolsDbContext _context;
        public BlogRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Blog> GetAllBlogs()
        {
            return _context.Blogs.ToList();
        }
        public Blog GetBlogById(int blogId)
        {
            return _context.Blogs.Include(c => c.BlogGroup).Include(c=>c.BlogType).First(c => c.BlogId == blogId);
        }
        public void InsertBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdateBlog(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;
        }
    }
}
