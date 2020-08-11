

using System.Collections.Generic;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolTrainingTypeService
    {
        List<int> GetSchoolTrainingTypeId(int schoolId);
        void AddTrainingTypeForSchool(int schoolId, int typeId);
        void DeleteSchoolTrainingTypes(int schoolId);
    }
}