using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolCommentService
    {
        SchoolCommentsViewModel GetSchoolComments(int pageId,int take,int schoolId);
        SchoolComment GetSchoolCommentById(int commentId);
        void DeleteComment(SchoolComment comment);
        bool IsCommentForUser(int userId, int commentId);
        SchoolComment AddComment(SchoolComment comment);
        void EditComment(SchoolComment comment);
    }
}