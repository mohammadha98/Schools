using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.BlogRepositories
{
    public class BlogGroupRepository : IBlogGroupsRepository
    {
        private SchoolsDbContext _context;
        public BlogGroupRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public List<BlogGroup> GetAllGroups()
        {
            return _context.BlogGroups.ToList();
        }

        public BlogGroup GetGroupById(int groupId)
        {
            return _context.BlogGroups.Find(groupId);
        }

        public void InsertGroup(BlogGroup blogGroup)
        {
            _context.BlogGroups.Add(blogGroup);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateGroup(BlogGroup blogGroup)
        {
            _context.Entry(blogGroup).State = EntityState.Modified;
        }
    }
}
