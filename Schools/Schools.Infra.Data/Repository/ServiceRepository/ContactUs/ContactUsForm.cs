using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;
using Schools.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Infra.Data.Repository.ServiceRepository.ContactUs
{
    public class ContactUsForm : IContactUsFormRepository
    {
        private SchoolsDbContext _context;
        public ContactUsForm(SchoolsDbContext context)
        {
            _context = context;
        }
        public void InsertQuestion(Domain.Models.ContactUs.ContactUsForm contactUsForm)
        {
            _context.ContactUsForms.Add(contactUsForm);
            _context.SaveChanges();
        }
    }
}
