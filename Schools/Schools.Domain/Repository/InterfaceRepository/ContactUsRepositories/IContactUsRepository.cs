using Schools.Domain.Models.ContactUs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories
{
    public interface IContactUsRepository
    {
        IEnumerable<ContactUs> GetAllContactUs();
        ContactUs GetContactUsById(int id);
        IEnumerable<ContactUs> GetLast();
        void AddContactUs(ContactUs contactUs);
        void UpdateContacUs(ContactUs contactUs);
    }
}
