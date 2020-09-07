using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.ContactUs
{
    [PermissionsChecker(1)]
    public class AddModel : PageModel
    {
        private IContactUsRepository _contactUs;
        public AddModel(IContactUsRepository contactUs)
        {
            _contactUs = contactUs;
        }

        [BindProperty]
        public Domain.Models.ContactUs.ContactUs ContactUs { get; set; }
        public void OnGet()
        {
            var contactUs = _contactUs.GetLast();
            if (contactUs!= null)
            {
                Response.Redirect("/ManagementPanel");
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var contactUs = new Domain.Models.ContactUs.ContactUs()
            {
                Address = ContactUs.Address,
                Title = ContactUs.Title,
                PhoneNumber = ContactUs.PhoneNumber,
                Email = ContactUs.Email,
                ResponseTime = ContactUs.ResponseTime,
                IsDelete = false
            };

            _contactUs.AddContactUs(contactUs);
            return RedirectToPage("Index");
        }
    }
}
