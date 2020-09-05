using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.ViewModels;
using Schools.Domain.Models.Users;
using Schools.Domain.Models.Users.Permissions;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.Application.Service.Services.Users
{
    public class UserRoleService : IUserRoleService
    {
        private IUserRoleRepository _role;

        public UserRoleService(IUserRoleRepository role)
        {
            _role = role;
        }
        public void AddRole(AddRoleViewModel role)
        {
            var roleModel = new Role()
            {
                IsDelete = false,
                RoleTitle = role.RoleTitle
            };
            _role.AddRole(roleModel);
            foreach (var permissionId in role.Permissions)
            {
                var rolePermission=new RolePermission()
                {
                    IsDelete = false,
                    PermissionId = permissionId,
                    RoleId = roleModel.RoleId
                };
                _role.AddRolePermission(rolePermission);
            }
            _role.SaveChange();
        }

        public bool DeleteRole(int roleId)
        {
            var role = _role.GetRoleById(roleId);
            if (role == null) return false;

            if (role.UserRoles.Any())
            {
                return false;
            }

            foreach (var rp in role.RolePermissions)
            {
                _role.RemoveRolePermission(rp);
            }
            role.IsDelete = true;
            _role.EditRole(role);

            return true;
        }

        public void EditRole(Role role, List<int> permissions)
        {
            var rpList = _role.GetRolePermissionsByRoleId(role.RoleId);
            foreach (var rp in rpList)
            {
                _role.RemoveRolePermission(rp);
            }
            foreach (var permissionId in permissions)
            {
                var rolePermission = new RolePermission()
                {
                    IsDelete = false,
                    PermissionId = permissionId,
                    RoleId = role.RoleId
                };
                _role.AddRolePermission(rolePermission);
            }
            _role.SaveChange();
        }
    }
}