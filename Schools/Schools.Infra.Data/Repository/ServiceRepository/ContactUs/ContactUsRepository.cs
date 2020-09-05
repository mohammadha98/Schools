using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;
using Schools.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schools.Infra.Data.Repository.ServiceRepository.ContactUs
{
    public class ContactUsRepository : IContactUsRepository
    {
        private SchoolsDbContext _context;
        public ContactUsRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public void AddContactUs(Domain.Models.ContactUs.ContactUs contactUs)
        {
            _context.ContactUs.Add(contactUs);
            _context.SaveChanges();
        }

        public IEnumerable<Domain.Models.ContactUs.ContactUs> GetAllContactUs()
        {
            return _context.ContactUs.ToList();
        }

        public Domain.Models.ContactUs.ContactUs GetContactUsById(int id)
        {
            return _context.ContactUs.Find(id);
        }

        public IEnumerable<Domain.Models.ContactUs.ContactUs> GetLast()
        {
            return _context.ContactUs.OrderByDescending(c => c.ContactId).Take(1);
        }

        public void UpdateContacUs(Domain.Models.ContactUs.ContactUs contactUs)
        {
            _context.ContactUs.Update(contactUs);
            _context.SaveChanges();
        }
    }
}
