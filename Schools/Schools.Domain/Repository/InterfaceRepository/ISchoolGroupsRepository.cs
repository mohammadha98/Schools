using Schools.Domain.Models.Schools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Domain.Repository.InterfaceRepository
{
    public interface ISchoolGroupsRepository
    {
        List<SchoolGroup> GetAllGroups();
        SchoolGroup GetSchoolGroupById(int groupId);
    }
}
