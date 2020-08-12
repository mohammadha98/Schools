using System.Collections.Generic;
using System.Linq;
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