using Schools.Domain.Models.Schools;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolRateRepository
    {
        void AddRate(SchoolRate rate);
        SchoolRate GetSchoolRate(int userId, int schoolId);

    }
}