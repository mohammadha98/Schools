using System.Collections.Generic;
using Schools.Domain.Models.Schools.TrainingTypes;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolTrainingTypeRepository:ISchoolTrainingTypeRepository
    {
        private SchoolsDbContext _context;

        public SchoolTrainingTypeRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public void AddSchoolTrainingType(SchoolTrainingType type)
        {
            _context.SchoolTrainingTypes.Add(type);
            _context.SaveChanges();
        }

        public void DeleteSchoolTrainingTypes(SchoolTrainingType type)
        {
            type.IsDelete = true;
            _context.Update(type);
        }

        public IEnumerable<SchoolTrainingType> GetSchoolTrainingTypes()
        {
            return _context.SchoolTrainingTypes;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}