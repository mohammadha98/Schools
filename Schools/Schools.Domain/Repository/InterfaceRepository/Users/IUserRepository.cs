using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        List<string> GetAllUserRolesByUserId(int userId);
        List<School> GetAllSchoolInUserLikesByUserId(int userId);
        List<Role> GetAllRoles();
        User GetUserById(int userId);
        int AddUser(User user);
        void AddRolesForUser(List<int> SelectedRoles, int userId);
        bool IsUserExist(int userId);
    }
}