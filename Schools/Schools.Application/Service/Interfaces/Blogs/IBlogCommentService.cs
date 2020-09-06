using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Domain.Models.Blogs;

namespace Schools.Application.Service.Interfaces.Blogs
{
    public interface IBlogCommentService
    {
        BlogCommentsViewModel GetBlogComments(int pageId, int take, int blogId);
        BlogComment GetBlogCommentById(int commentId);
        void DeleteComment(BlogComment comment);
        bool IsCommentForUser(int userId, int commentId);
        BlogComment AddComment(BlogComment comment);
        void EditComment(BlogComment comment);
    }
}