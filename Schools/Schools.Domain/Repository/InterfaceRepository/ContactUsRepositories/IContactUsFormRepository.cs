using Schools.Domain.Models.ContactUs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories
{
    public interface IContactUsFormRepository
    {
        void InsertQuestion(ContactUsForm contactUsForm);
    }
}
