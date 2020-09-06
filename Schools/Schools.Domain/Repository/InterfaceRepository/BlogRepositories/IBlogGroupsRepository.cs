using Schools.Domain.Models.Blogs;
using System.Collections.Generic;

namespace Schools.Domain.Repository.InterfaceRepository.BlogRepositories
{
    public interface IBlogGroupsRepository
    {
        List<BlogGroup> GetAllGroups();
        BlogGroup GetGroupById(int groupId);
        void InsertGroup(BlogGroup blogGroup);
        void UpdateGroup(BlogGroup blogGroup);
        void Save();
    }
}
