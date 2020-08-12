using System.Collections.Generic;
using Schools.Domain.Models.Schools.TrainingTypes;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolTrainingTypeRepository
    {
        void AddSchoolTrainingType(SchoolTrainingType type);
        void DeleteSchoolTrainingTypes(SchoolTrainingType type);
        IEnumerable<SchoolTrainingType> GetSchoolTrainingTypes();
        void SaveChanges();
    }
}