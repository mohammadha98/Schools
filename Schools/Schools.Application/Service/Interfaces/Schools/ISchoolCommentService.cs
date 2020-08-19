using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolCommentService
    {
        SchoolCommentsViewModel GetSchoolComments(int pageId,int take,int schoolId);
        SchoolComment GetSchoolCommentById(int commentId);
        void DeleteComment(int commentId);
        bool IsCommentForUser(int userId, int commentId);
        void AddComment(SchoolComment comment);
        void EditComment(SchoolComment comment);
    }
}