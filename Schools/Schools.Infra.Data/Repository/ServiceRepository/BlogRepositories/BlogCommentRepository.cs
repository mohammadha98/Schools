using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.BlogRepositories
{
    public class BlogCommentRepository: IBlogCommentRepository
    {
        private SchoolsDbContext _db;

        public BlogCommentRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public IQueryable<BlogComment> GetBlogComments(int blogId)
        {
            return _db.BlogComments.Include(c=>c.User).Where(c => c.BlogId == blogId);
        }

        public BlogComment GetComment(int commentId)
        {
            return _db.BlogComments.Include(c=>c.User).SingleOrDefault(b => b.CommentId == commentId);
        }

        public BlogComment GetComment(int commentId, int userId)
        {
            return _db.BlogComments.Include(c => c.User).SingleOrDefault(b => b.CommentId == commentId && b.UserId==userId);

        }

        public void UpdateComment(BlogComment comment)
        {
            _db.BlogComments.Update(comment);
            _db.SaveChanges();
        }

        public void AddComment(BlogComment comment)
        {
            _db.BlogComments.Add(comment);
            _db.SaveChanges();
        }
    }
}