using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.ContactUs
{
    public class DeleteModel : PageModel
    {
        private IContactUsRepository _contactUs;
        public DeleteModel(IContactUsRepository contactUs)
        {
            _contactUs = contactUs;
        }

        [BindProperty]
        public Domain.Models.ContactUs.ContactUs ContactUs { get; set; }
        public void OnGet(int id)
        {
            ContactUs = _contactUs.GetContactUsById(id);
        }

        public IActionResult OnPost()
        {
            var contactus = _contactUs.GetContactUsById(ContactUs.ContactId);
            contactus.IsDelete = true;

            _contactUs.UpdateContacUs(contactus);

            return RedirectToPage("Index");
        }
    }
}
