using System.Collections.Generic;
using Schools.Domain.Models.ContactUs;

namespace Schools.Application.ViewModels
{
    public class ContactUsFormViewModel
    {
        public List<ContactUsForm> ContactUses { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public bool IsPosted { get; set; }
    }
}