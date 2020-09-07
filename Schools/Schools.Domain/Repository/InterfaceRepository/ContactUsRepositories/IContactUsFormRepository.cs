using Schools.Domain.Models.ContactUs;
using System.Linq;

namespace Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories
{
    public interface IContactUsFormRepository
    {
        void EditContactUs(ContactUsForm contactUs);
        void InsertQuestion(ContactUsForm contactUsForm);
        IQueryable<ContactUsForm> GetContactUses();
        ContactUsForm GetContactUsById(int contactUsFormId);
    }
}
