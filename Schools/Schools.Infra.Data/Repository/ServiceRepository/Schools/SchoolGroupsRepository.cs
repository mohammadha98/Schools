using System.Collections.Generic;
using System.Data.Entity;
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

        public void EditGroup(SchoolGroup @group)
        {
            _context.SchoolGroups.Update(group);
            _context.SaveChanges();
        }

        public void DeleteGroup(int groupId)
        {
            var group = GetSchoolGroupById(groupId);
            if (group == null)
                return;

            var sub = _context.SchoolGroups.Where(s => s.ParentId == groupId);
            foreach (var item in sub)
            {
                item.IsDelete = true;
                _context.SchoolGroups.Update(item);
            }

            group.IsDelete = true;
            _context.SaveChanges();
        }

        public List<SchoolGroup> GetAllGroups()
        {
            return _context.SchoolGroups.ToList();
        }

        public SchoolGroup GetSchoolGroupById(int groupId)
        {
            return _context.SchoolGroups
                .Include(g => g.SchoolsSub)
                .Include(g => g.Schools).SingleOrDefault(g => g.GroupId == groupId);
        }
    }
}
