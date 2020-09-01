using System.Linq;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolRulesRepository:ISchoolRulesRepository
    {
        private SchoolsDbContext _db;

        public SchoolRulesRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public SchoolRules GetRule()
        {
           return _db.SchoolRules.FirstOrDefault();
        }

        public void AddRule(SchoolRules rule)
        {
            _db.SchoolRules.Add(rule);
            _db.SaveChanges();
        }

        public void EditRule(SchoolRules rule)
        {
            _db.SchoolRules.Update(rule);
            _db.SaveChanges();
        }
    }
}