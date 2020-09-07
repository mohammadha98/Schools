using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;
using Schools.Infra.Data.Context;
using System.Linq;

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
            if (_context.ContactUs.Any())
            {
                return;
            }
            _context.ContactUs.Add(contactUs);
            _context.SaveChanges();
        }

        public Domain.Models.ContactUs.ContactUs GetContactUsById(int id)
        {
            return _context.ContactUs.Find(id);
        }

        public Domain.Models.ContactUs.ContactUs GetLast()
        {
            return _context.ContactUs.FirstOrDefault();
        }

        public void UpdateContactUs(Domain.Models.ContactUs.ContactUs contactUs)
        {
            _context.ContactUs.Update(contactUs);
            _context.SaveChanges();
        }
    }
}
