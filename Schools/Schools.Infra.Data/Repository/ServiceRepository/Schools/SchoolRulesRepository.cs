using System.Linq;
using Schools.Domain.Models;
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
        public Rules GetRule()
        {
           return _db.Rules.FirstOrDefault();
        }

        public void AddRule(Rules rule)
        {
            _db.Rules.Add(rule);
            _db.SaveChanges();
        }

        public void EditRule(Rules rule)
        {
            _db.Rules.Update(rule);
            _db.SaveChanges();
        }
    }
}