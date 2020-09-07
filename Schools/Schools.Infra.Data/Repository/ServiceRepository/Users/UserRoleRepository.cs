using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Users;
using Schools.Domain.Models.Users.Permissions;
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
            return _db.UserRoles.Include(r => r.Role);

        }

        public Role GetRoleById(int roleId)
        {
            return _db.Roles.Include(r => r.UserRoles).Include(r=>r.RolePermissions).SingleOrDefault(r => r.RoleId == roleId);
        }

        public Role FindRole(int roleId)
        {
            return _db.Roles.Find(roleId);
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

        public void RemoveUserRole(int userId)
        {
            var roles = _db.UserRoles.Where(r => r.UserId == userId);
            foreach (var item in roles)
            {
                _db.UserRoles.Remove(item);
            }

            _db.SaveChanges();
        }


        public void AddUserRole(UserRole role)
        {
            _db.UserRoles.Add(role);
            _db.SaveChanges();
        }

        public void AddRole(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
        }

        public void EditRole(Role role)
        {
            _db.Roles.Update(role);
            _db.SaveChanges();
        }

        public void SaveChange()
        {
            _db.SaveChanges();
        }

        public List<RolePermission> GetRolePermissionsByRoleId(int roleId)
        {
            return _db.RolePermissions.Where(r => r.RoleId == roleId).ToList();
        }

        public List<Permission> GetPermissions()
        {
            return _db.Permissions.ToList();
        }

        public bool CheckPermission(int userId, int permissionId)
        {
            var userRoles = _db.UserRoles.Where(r => r.UserId == userId);

            return _db.RolePermissions.Any(r => userRoles.Any(role => role.RoleId == r.RoleId) && r.PermissionId == permissionId);
        }

        public void AddRolePermission(RolePermission rolePermission)
        {
            _db.RolePermissions.Add(rolePermission);
        }

        public void RemoveRolePermission(RolePermission rolePermission)
        {
            _db.RolePermissions.Remove(rolePermission);

        }
    }
}