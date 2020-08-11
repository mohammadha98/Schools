using Schools.Domain.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Domain.Repository.InterfaceRepository.BlogRepositories
{
    public interface IBlogGroupsRepository
    {
        IEnumerable<BlogGroup> GetAllGroups(string parameter);
        BlogGroup GetGroupById(int groupId);
        void InsertGroup(BlogGroup blogGroup);
        void UpdateGroup(BlogGroup blogGroup);
        void Save();
    }
}
