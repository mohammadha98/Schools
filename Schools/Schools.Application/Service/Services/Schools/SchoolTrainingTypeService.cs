using System.Collections.Generic;
using System.Linq;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Models.Schools.TrainingTypes;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolTrainingTypeService:ISchoolTrainingTypeService
    {
        private ISchoolTrainingTypeRepository _type;

        public SchoolTrainingTypeService(ISchoolTrainingTypeRepository type)
        {
            _type = type;
        }

        public List<int> GetSchoolTrainingTypeId(int schoolId)
        {
           
           return _type.GetSchoolTrainingTypes().Where(t => t.SchoolId == schoolId).Select(s=>s.TypeId).ToList();
        }

        public void AddTrainingTypeForSchool(int schoolId, int typeId)
        {
            var typeModel=new SchoolTrainingType()
            {
                IsDelete = false,
                TypeId = typeId,
                SchoolId = schoolId
            };
            _type.AddSchoolTrainingType(typeModel);
        }

        public void DeleteSchoolTrainingTypes(int schoolId)
        {
            var schoolTypes = _type.GetSchoolTrainingTypes().Where(t => t.SchoolId == schoolId).ToList();
            foreach (var item in schoolTypes)
            {
                _type.DeleteSchoolTrainingTypes(item);
            }
            _type.SaveChanges();
        }

    }
}