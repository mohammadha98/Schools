using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.ContactUses;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.ContactUs;
using Schools.Domain.Repository.InterfaceRepository.ContactUsRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.ContactUs.HelpForm
{
    [PermissionsChecker(23)]
    public class ShowModel : PageModel
    {
        private IContactUsFormService _service;
        private IContactUsFormRepository _repository;

        public ShowModel(IContactUsFormService service, IContactUsFormRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public ContactUsForm ContactUs { get; set; }
        public void OnGet(int id)
        {
            ContactUs = _repository.GetContactUsById(id);
            if (ContactUs==null)
            {
                Response.Redirect("/ManamgenetPanel/ContactUs/HelpForm");
            }
        }

        public IActionResult OnPost(int id,string answer)
        {
            ContactUs = _repository.GetContactUsById(id);
            if (ContactUs == null)
            {
                Response.Redirect("/ManamgenetPanel/ContactUs/HelpForm");
            }
            if (string.IsNullOrEmpty(answer))
            {
                ModelState.AddModelError("answer","پاسخ را وارد کنید");
                return Page();
            }
           
            _service.SendAnswerForContactUs(ContactUs,answer);
            return RedirectToPage("Index");
        }
    }
}
