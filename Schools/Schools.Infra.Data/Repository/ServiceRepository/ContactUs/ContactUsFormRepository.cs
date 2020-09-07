using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;
using Schools.Infra.Data.Context;
using System.Linq;

namespace Schools.Infra.Data.Repository.ServiceRepository.ContactUs
{
    public class ContactUsFormRepository : IContactUsFormRepository
    {
        private SchoolsDbContext _context;
        public ContactUsFormRepository(SchoolsDbContext context)
        {
            _context = context;
        }

        public void EditContactUs(Domain.Models.ContactUs.ContactUsForm contactUs)
        {
            _context.ContactUsForms.Update(contactUs);
            _context.SaveChanges();
        }

        public void InsertQuestion(Domain.Models.ContactUs.ContactUsForm contactUsForm)
        {
            _context.ContactUsForms.Add(contactUsForm);
            _context.SaveChanges();
        }

        public IQueryable<Domain.Models.ContactUs.ContactUsForm> GetContactUses()
        {
            return _context.ContactUsForms;
        }

        public Domain.Models.ContactUs.ContactUsForm GetContactUsById(int contactUsFormId)
        {
            return _context.ContactUsForms.SingleOrDefault(c => c.ContactId == contactUsFormId);
        }
    }
}
