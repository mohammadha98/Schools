using System.Data.Entity;
using System.Linq;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolCommentRepository:ISchoolCommentRepository
    {
        private SchoolsDbContext _db;

        public SchoolCommentRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public IQueryable<SchoolComment> GetCommentsBySchoolId(int schoolId)
        {
            return _db.SchoolComments.Include(c=>c.User).Where(s => s.SchoolId == schoolId);
        }

        public SchoolComment GetSchoolCommentById(int commentId)
        {
            return _db.SchoolComments.SingleOrDefault(s => s.CommentId == commentId);
        }

        public void AddSchoolComment(SchoolComment comment)
        {
            _db.SchoolComments.Add(comment);
            _db.SaveChanges();
        }

        public void EditSchoolComment(SchoolComment comment)
        {
            _db.SchoolComments.Update(comment);
            _db.SaveChanges();
        }

        public void DeleteSchoolComment(int commentId)
        {
            var comment = GetSchoolCommentById(commentId);
            _db.SchoolComments.Remove(comment);
            _db.SaveChanges();
        }
    }
}