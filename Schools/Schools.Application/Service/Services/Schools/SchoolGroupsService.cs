using Schools.Application.Service.Interfaces;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolGroupsService : ISchoolGroupsService
    {
        private ISchoolGroupsRepository _schoolGroupsRepository;

        public SchoolGroupsService(ISchoolGroupsRepository schoolGroupsRepository)
        {
            this._schoolGroupsRepository = schoolGroupsRepository;
        }

       

        
    }
}
