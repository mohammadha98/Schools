using System.Linq;
using Schools.Domain.Models.Blogs;

namespace Schools.Domain.Repository.InterfaceRepository.BlogRepositories
{
    public interface IBlogCommentRepository
    {
        IQueryable<BlogComment> GetBlogComments(int blogId);
        BlogComment GetComment(int commentId);
        BlogComment GetComment(int commentId,int userId);
        void UpdateComment(BlogComment comment);
        void AddComment(BlogComment comment);

    }
}