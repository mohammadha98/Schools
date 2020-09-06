using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        
        List<School> GetAllSchoolInUserLikesByUserId(int userId);
        User GetUserById(int userId);
        User FindUser(int userId);
        User GetUserWithRelations(int userId);
        User GetUserIdByEmail(string email);
        int AddUser(User user);
        void EditUser(User user);
        bool IsUserExist(int userId);
        void Save();
    }
}