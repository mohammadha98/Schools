using Schools.Domain.Models.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Domain.Repository.InterfaceRepository.BlogRepositories
{
    public interface IBlogTypeRepository
    {
        IEnumerable<BlogType> GetAllType();
        IEnumerable<BlogType> FilterType(int id);

    }
}
