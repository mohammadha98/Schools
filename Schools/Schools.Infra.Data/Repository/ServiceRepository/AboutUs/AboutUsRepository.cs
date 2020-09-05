using Schools.Domain.Repository.InterfaceRepository.AboutUsRepository;
using Schools.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schools.Infra.Data.Repository.ServiceRepository.AboutUs
{
    public class AboutUsRepository : IAboutUsRepository
    {
        private SchoolsDbContext _context;
        public AboutUsRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public Domain.Models.AboutUs.AboutUs GetAboutUsById(int id)
        {
            return _context.AboutUs.Find(id);
        }



        public Domain.Models.AboutUs.AboutUs GetLast()
        {
            return _context.AboutUs.FirstOrDefault();
        }

        public void Insert(Domain.Models.AboutUs.AboutUs aboutUs)
        {
            if (_context.AboutUs.Any()) return;
            _context.AboutUs.Add(aboutUs);
            _context.SaveChanges();
        }

        public void Update(Domain.Models.AboutUs.AboutUs aboutUs)
        {
            _context.AboutUs.Update(aboutUs);
            _context.SaveChanges();
        }
    }
}
