using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schools.Infra.Data.Repository.ServiceRepository.BlogRepositoris
{
    public class BlogTypeRepository : IBlogTypeRepository
    {
        private SchoolsDbContext _context;
        public BlogTypeRepository(SchoolsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogType> FilterType(int id)
        {
            return _context.BlogTypes.Where(b => b.TypeId == id).ToList();
        }

        public IEnumerable<BlogType> GetAllType()
        {
            return _context.BlogTypes.ToList();
        }
    }
}
