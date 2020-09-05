using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.ContactUs
{
    public class EditModel : PageModel
    {
        private IContactUsRepository _contactUs;
        public EditModel(IContactUsRepository contactUs)
        {
            _contactUs = contactUs;
        }
        [BindProperty]
        public Domain.Models.ContactUs.ContactUs ContactUs { get; set; }
        public void OnGet()
        {
            ContactUs = _contactUs.GetLast();
            if (ContactUs==null)
            {
                Response.Redirect("/ManagementPanel/ContactUs");
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var contactUs = _contactUs.GetLast();
            if (contactUs == null) return RedirectToPage("Index");

            contactUs.PhoneNumber = ContactUs.PhoneNumber;
            contactUs.Email = ContactUs.Email;
            contactUs.Address = ContactUs.Address;
            contactUs.Title = ContactUs.Title;
            contactUs.ResponseTime = ContactUs.ResponseTime;
            contactUs.IsDelete = false;

            _contactUs.UpdateContactUs(contactUs);
            return RedirectToPage("Index");
        }
    }
}
