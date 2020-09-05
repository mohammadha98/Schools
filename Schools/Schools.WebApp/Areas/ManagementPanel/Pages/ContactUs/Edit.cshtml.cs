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
        public void OnGet(int id)
        {
            ContactUs = _contactUs.GetContactUsById(id);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            var contactus = _contactUs.GetContactUsById(id);
            contactus.Title = ContactUs.Title;
            contactus.PhoneNumber = ContactUs.PhoneNumber;
            contactus.Address = ContactUs.Address;
            contactus.ResponseTime = ContactUs.ResponseTime;
            contactus.Email = ContactUs.Email;
            contactus.IsDelete = false;

            _contactUs.UpdateContacUs(contactus);
            return RedirectToPage("Index");
        }
    }
}
