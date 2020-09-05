using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Repository.InterfaceRepository.AboutUsRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.AboutUs
{
    public class EditModel : PageModel
    {
        private IAboutUsRepository _aboutUs;
        public EditModel(IAboutUsRepository aboutUs)
        {
            _aboutUs = aboutUs;
        }
        [BindProperty]
        public Domain.Models.AboutUs.AboutUs AboutUs { get; set; }
        public void OnGet()
        {
            AboutUs = _aboutUs.GetLast();
            if (AboutUs == null)
            {
                Response.Redirect("/ManagementPanel/AboutUs");
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var aboutUs = _aboutUs.GetLast();
            if (aboutUs == null) return Redirect("/ManagementPanel/AboutUs");


            aboutUs.Text = AboutUs.Text;
            _aboutUs.Update(aboutUs);
            return RedirectToPage("Index");
        }
    }
}
