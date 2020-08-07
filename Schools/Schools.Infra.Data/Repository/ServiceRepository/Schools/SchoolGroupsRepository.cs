using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolGroupsRepository : ISchoolGroupsRepository
    {
        SchoolsDbContext _context;
        public SchoolGroupsRepository(SchoolsDbContext context)
        {
           _context = context;
        }

        public void CreateGroup(SchoolGroup schoolGroup)
        {
            _context.SchoolGroups.Add(schoolGroup);
            _context.SaveChanges();
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
