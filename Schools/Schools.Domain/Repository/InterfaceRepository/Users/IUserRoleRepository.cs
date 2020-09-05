using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Users;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserRoleRepository
    {
        IQueryable<Role> GetAllRoles();
        IQueryable<UserRole> GetUserRoles();
        int AddRolesForUser(List<int> selectedRoles, int userId);
        void AddUserRole(UserRole role);
    }
}