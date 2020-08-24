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

        public IEnumerable<Blog> GetAllBlogs()
        {
            return _context.Blogs.Include(b => b.BlogGroup).Include(b => b.BlogType).ToList();
        }

        public Blog GetBlogById(int blogId)
        {
            return _context.Blogs.Include(b => b.BlogGroup).Include(b => b.BlogType).First(b => b.BlogId == blogId);
        }

        public Tuple<List<BlogComment>, int> GetBlogComments(int blogId, int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            int pageCount = _context.BlogComments.Where(b => !b.IsDelete && b.BlogId == blogId).Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }
            return Tuple.Create(
                _context.BlogComments.Where(b => !b.IsDelete && b.BlogId == blogId).Skip(skip).Take(take)
                .OrderByDescending(b => b.CreateDate).ToList(), pageCount);
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
