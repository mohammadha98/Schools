using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.ContactUs
{
    [PermissionsChecker(1)]
    public class IndexModel : PageModel
    {
        private IContactUsRepository _contactUs;
        public IndexModel(IContactUsRepository contactUs)
        {
            _contactUs = contactUs;
        }

        [BindProperty]
        public Domain.Models.ContactUs.ContactUs ContactUs { get; set; }
        public void OnGet()
        {
            ContactUs = _contactUs.GetLast();
        }
    }
}
