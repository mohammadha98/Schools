using System.Linq;
using Schools.Domain.Models.Schools;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolCommentRepository
    {
        IQueryable<SchoolComment> GetCommentsBySchoolId(int schoolId);
        SchoolComment GetSchoolCommentById(int commentId);
        void AddSchoolComment(SchoolComment comment);
        void EditSchoolComment(SchoolComment comment);
        void DeleteSchoolComment(SchoolComment comment);
    }
}