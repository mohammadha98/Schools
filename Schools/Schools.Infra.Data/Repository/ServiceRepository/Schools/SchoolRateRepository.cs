using System.Linq;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolRateRepository : ISchoolRateRepository
    {
        private SchoolsDbContext _db;

        public SchoolRateRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public void AddRate(SchoolRate rate)
        {
            _db.SchoolRates.Add(rate);
            _db.SaveChanges();
        }

        public SchoolRate GetSchoolRate(int userId, int schoolId)
        {
            return _db.SchoolRates.FirstOrDefault(u => u.UserId == userId && u.SchoolId == schoolId);
        }
    }
}