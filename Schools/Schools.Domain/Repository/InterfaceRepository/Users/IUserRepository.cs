using Schools.Domain.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        User GetUserById(int userId);
        bool IsUserExist(int userId);
    }
}