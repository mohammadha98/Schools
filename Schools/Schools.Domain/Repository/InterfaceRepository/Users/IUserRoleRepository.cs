using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Users;
using Schools.Domain.Models.Users.Permissions;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserRoleRepository
    {
        IQueryable<Role> GetAllRoles();
        IQueryable<UserRole> GetUserRoles();
        Role GetRoleById(int roleId);
        Role FindRole(int roleId);
        int AddRolesForUser(List<int> selectedRoles, int userId);
        void AddUserRole(UserRole role);
        void AddRole(Role role);
        void EditRole(Role role);
        void SaveChange();

        #region Permissions

        List<RolePermission> GetRolePermissionsByRoleId(int roleId);
        List<Permission> GetPermissions();
        bool CheckPermission(int userId, int permissionId);
        void AddRolePermission(RolePermission rolePermission);
        void RemoveRolePermission(RolePermission rolePermission);

        #endregion
    }
}