using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.ContactUses;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.ContactUs.HelpForm
{
    [PermissionsChecker(23)]
    public class IndexModel : PageModel
    {
        private IContactUsFormService _contact;

        public IndexModel(IContactUsFormService contact)
        {
            _contact = contact;
        }
        public ContactUsFormViewModel ContactUsModel { get; set; }
        public void OnGet(int pageId=1,bool isPosted=false)
        {
            ContactUsModel = _contact.GetContactUses(pageId, 12, isPosted);
        }
    }
}
