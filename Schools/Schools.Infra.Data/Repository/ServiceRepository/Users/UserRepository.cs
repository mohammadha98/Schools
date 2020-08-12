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

        public void AddRolesForUser(List<int> SelectedRoles, int userId)
        {
            foreach(var item in SelectedRoles)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    IsDelete = false,
                    UserId = userId,
                    RoleId = item,
                });
                _context.SaveChanges();
            }
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
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