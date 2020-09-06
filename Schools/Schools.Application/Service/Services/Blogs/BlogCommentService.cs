using System;
using System.Linq;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.Application.Service.Services.Blogs
{
    public class BlogCommentService : IBlogCommentService
    {
        private IBlogCommentRepository _comment;

        public BlogCommentService(IBlogCommentRepository comment)
        {
            _comment = comment;
        }
        public BlogCommentsViewModel GetBlogComments(int pageId, int take, int blogId)
        {
            var comments = _comment.GetBlogComments(blogId);
            var mainComments = comments.Where(c => c.Answer == null).OrderByDescending(c => c.CreateDate);
            var answerComments = comments.Where(c => c.Answer != null);
            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(mainComments.Count() / (double)take);
            var commentsModel = new BlogCommentsViewModel()
            {
                BlogComments = mainComments.Skip(skip).Take(take).ToList(),
                AnswerComments = answerComments.ToList(),
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                CommentsCount = comments.Count()
            };
            return commentsModel;
        }

        public BlogComment GetBlogCommentById(int commentId)
        {
            return _comment.GetComment(commentId);
        }

        public void DeleteComment(BlogComment comment)
        {
            comment.IsDelete = true;
            _comment.UpdateComment(comment);
        }

        public bool IsCommentForUser(int userId, int commentId)
        {
            return _comment.GetComment(commentId, userId) != null;

        }

        public BlogComment AddComment(BlogComment comment)
        {
            comment.CreateDate=DateTime.Now;
            _comment.AddComment(comment);
            return _comment.GetComment(comment.CommentId);
        }

        public void EditComment(BlogComment comment)
        {
            _comment.UpdateComment(comment);
        }
    }
}