using System.Collections.Generic;
using Schools.Domain.Models.Schools;


namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolGroupsService
    {
        bool IsGroupHasSchool(int groupId);
        List<SchoolGroup> GetSchoolGroupsByShireTitle(string shireTitle);
        List<SchoolGroup> GetSchoolGroups();
    }
}
