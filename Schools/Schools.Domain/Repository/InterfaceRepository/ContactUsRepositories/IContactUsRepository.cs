using Schools.Domain.Models.ContactUs;

namespace Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories
{
    public interface IContactUsRepository
    {
        ContactUs GetContactUsById(int id);
        ContactUs GetLast();
        void AddContactUs(ContactUs contactUs);
        void UpdateContactUs(ContactUs contactUs);
    }
}
