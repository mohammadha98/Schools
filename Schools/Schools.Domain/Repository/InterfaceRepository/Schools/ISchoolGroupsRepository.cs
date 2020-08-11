using Schools.Domain.Models.Schools;
using System.Collections.Generic;


namespace Schools.Domain.Repository.InterfaceRepository
{
    public interface ISchoolGroupsRepository
    {
        List<SchoolGroup> GetAllGroups();
        SchoolGroup GetSchoolGroupById(int groupId);
        void CreateGroup(SchoolGroup schoolGroup);
        void DeleteGroup(SchoolGroup schoolGroup);
        void Update(SchoolGroup schoolGroup);
    }
}
