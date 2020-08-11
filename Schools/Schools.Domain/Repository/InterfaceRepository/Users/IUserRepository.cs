using Schools.Domain.Models.Users;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        bool IsUserExist(int userId);
    }
}