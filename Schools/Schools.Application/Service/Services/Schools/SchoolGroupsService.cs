using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Schools.Application.Service.Interfaces;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolGroupsService : ISchoolGroupsService
    {
        private ISchoolGroupsRepository _groups;

        public SchoolGroupsService(ISchoolGroupsRepository schoolGroupsRepository)
        {
            _groups = schoolGroupsRepository;
        }


        public bool IsGroupHasSchool(int groupId)
        {
            var group = _groups.GetSchoolGroupById(groupId);
            if (group == null)
                return true;

            return group.Schools.Any() || group.SchoolsSub.Any();
        }
    }
}
