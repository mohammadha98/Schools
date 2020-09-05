using System;
using System.Linq;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolCommentService:ISchoolCommentService
    {
        private ISchoolCommentRepository _comment;

        public SchoolCommentService(ISchoolCommentRepository comment)
        {
            _comment = comment;
        }
        public SchoolCommentsViewModel GetSchoolComments(int pageId, int take, int schoolId)
        {
            var comments = _comment.GetCommentsBySchoolId(schoolId);
            var mainComments = comments.Where(c=>c.Answer==null).OrderByDescending(c => c.CreateDate);
            var answerComments = comments.Where(c => c.Answer != null);
            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(mainComments.Count() / (double)take);
            var commentsModel=new SchoolCommentsViewModel()
            {
                SchoolComments = mainComments.Skip(skip).Take(take).ToList(),
                AnswerComments = answerComments.ToList(),
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5
            };
            return commentsModel;
        }

        public SchoolComment GetSchoolCommentById(int commentId)
        {
            return _comment.GetSchoolCommentById(commentId);
        }

        public void DeleteComment(SchoolComment comment)
        {
            _comment.DeleteSchoolComment(comment);
        }

        public bool IsCommentForUser(int userId, int commentId)
        {
            var comment = GetSchoolCommentById(commentId);
            if (comment == null)
                return false;
            //False اگر نبود True اگر شناسه های کاربری برابر بودند 
            return comment.UserId == userId;
        }

        public SchoolComment AddComment(SchoolComment comment)
        {
            comment.CreateDate=DateTime.Now;
            comment.IsDelete = false;
            _comment.AddSchoolComment(comment);
            return _comment.GetSchoolCommentById(comment.CommentId);
        }

        public void EditComment(SchoolComment comment)
        {
            _comment.EditSchoolComment(comment);
        }
    }
}