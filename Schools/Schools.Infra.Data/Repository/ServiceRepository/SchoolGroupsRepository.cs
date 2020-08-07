using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schools.Infra.Data.Repository.ServiceRepository
{
    public class SchoolGroupsRepository : ISchoolGroupsRepository
    {
        Schools.Infra.Data.Context.SchoolsDbContext _context;
        public SchoolGroupsRepository(Schools.Infra.Data.Context.SchoolsDbContext context)
        {
            this._context = context;
        }

        public List<SchoolGroup> GetAllGroups()
        {
            return _context.SchoolGroups.ToList();
        }

        public SchoolGroup GetSchoolGroupById(int groupId)
        {
            return _context.SchoolGroups.Find(groupId);
        }
    }
}
