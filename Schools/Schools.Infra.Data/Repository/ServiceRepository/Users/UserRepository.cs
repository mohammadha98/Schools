using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Users
{
    public class UserRepository:IUserRepository
    {
        private SchoolsDbContext _context;

        public UserRepository(SchoolsDbContext context)
        {
            _context = context;
        }

        public List<School> GetAllSchoolInUserLikesByUserId(int userId)
        {
            return _context.UserLikes.Where(u => u.UserId == userId).Select(s => s.School).ToList();
        }

        public List<string> GetAllUserRolesByUserId(int userId)
        {
            return _context.UserRoles.Where(u => u.UserId == userId).Select(r => r.Role.RoleTitle).ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.UserId == userId);
        }

        public IQueryable<User> GetUsers()
        {
            return _context.Users;
        }

        public bool IsUserExist(int userId)
        {
            return _context.Users.Any(u => u.UserId == userId);
        }
    }
}