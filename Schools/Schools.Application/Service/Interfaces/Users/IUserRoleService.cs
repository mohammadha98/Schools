using System.Collections.Generic;
using Schools.Application.ViewModels;
using Schools.Domain.Models.Users;

namespace Schools.Application.Service.Interfaces.Users
{
    public interface IUserRoleService
    {
        void AddRole(AddRoleViewModel role);
        bool DeleteRole(int roleId);
        void EditRole(Role role,List<int>permissions);
    }
}