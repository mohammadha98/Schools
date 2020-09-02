using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Users
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private SchoolsDbContext _db;

        public UserRoleRepository(SchoolsDbContext db)
        {
            _db = db;
        }

        public IQueryable<Role> GetAllRoles()
        {
           return _db.Roles;
        }

        public IQueryable<UserRole> GetUserRoles()
        {
            return _db.UserRoles.Include(r=>r.Role);

        }

        public int AddRolesForUser(List<int> selectedRoles, int userId)
        {
            foreach (var item in selectedRoles)
            {
                _db.UserRoles.Add(new UserRole()
                {
                    IsDelete = false,
                    UserId = userId,
                    RoleId = item,
                });
            }
            _db.SaveChanges();

            return userId;
        }

        public void AddUserRole(UserRole role)
        {
            _db.UserRoles.Add(role);
            _db.SaveChanges();
        }
    }
}