using System.Linq;
using Schools.Domain.Models.Schools;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolRepository
    {
        IQueryable<School> GetAllSchools();
        School GetSchoolBySchoolId(int schoolId);
        School GetSchoolByUserId(int userId);
        void DeleteSchool(int schoolId);
        void AddSchool(School school);
        void EditSchool(School school);
    }
}