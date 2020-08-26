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

        public void AddComment(BlogComment comment)
        {
            _context.BlogComments.Add(comment);
            _context.SaveChanges();
        }

        public int CommentCount(int blogId)
        {
            return _context.BlogComments.Count(b => b.BlogId == blogId);
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return _context.Blogs.Include(b => b.BlogGroup).Include(b => b.BlogType).ToList();
        }

        public Blog GetBlogById(int blogId)
        {
            return _context.Blogs.Include(b => b.BlogGroup).Include(b => b.BlogType).First(b => b.BlogId == blogId);
        }

        public IEnumerable<Blog> GetLatesBlog()
        {
            return _context.Blogs.Include(b => b.BlogType).Include(b => b.BlogGroup).OrderByDescending(b => b.CreateDate).Take(4).ToList();
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
