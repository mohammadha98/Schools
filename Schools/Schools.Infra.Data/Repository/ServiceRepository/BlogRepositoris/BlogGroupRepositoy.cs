using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schools.Infra.Data.Repository.ServiceRepository.BlogRepositoris
{
    public class BlogGroupRepositoy : IBlogGroupsRepository
    {
        private SchoolsDbContext _context;
        public BlogGroupRepositoy(SchoolsDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BlogGroup> GetAllGroups(string parameter)
        {
            if (parameter == null)
            {
                return _context.BlogGroups.ToList();
            }
            else
            {
                var list = _context.BlogGroups.Where(b => b.GroupName.Contains(parameter) || b.GroupId.ToString().Contains(parameter)).ToList();
                return list.Distinct().ToList();
            }
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
