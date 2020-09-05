using System.Linq;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Users
{
    public class UserLikeRepository : IUserLikeRepository
    {
        private SchoolsDbContext _db;

        public UserLikeRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public void AddUserLike(UserLike like)
        {
            _db.UserLikes.Add(like);
            _db.SaveChanges();
        }

        public bool IsUserLikeSchool(int userId, int schoolId)
        {
            return _db.UserLikes.Any(u => u.UserId == userId && u.SchoolId == schoolId);
        }

        public UserLike GetUserLike(int schoolId, int userId)
        {
            return _db.UserLikes.FirstOrDefault(l => l.UserId == userId && l.SchoolId == schoolId);
        }

        public void EditUserLike(UserLike like)
        {
            _db.UserLikes.Update(like);
            _db.SaveChanges();
        }
    }
}