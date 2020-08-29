using Schools.Domain.Models.Users;

namespace Schools.Domain.Repository.InterfaceRepository.Users
{
    public interface IUserLikeRepository
    {
        void AddUserLike(UserLike like);
        bool IsUserLikeSchool(int userId, int schoolId);
        UserLike GetUserLike(int schoolId, int userId);
        void EditUserLike(UserLike like);
    }
}