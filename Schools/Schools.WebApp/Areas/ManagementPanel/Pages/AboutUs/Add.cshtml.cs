using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Repository.InterfaceRepository.AboutUsRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.AboutUs
{
    public class AddModel : PageModel
    {
        private IAboutUsRepository _aboutUs;
        public AddModel(IAboutUsRepository aboutUs)
        {
            _aboutUs = aboutUs;
        }
        [BindProperty]
        public Domain.Models.AboutUs.AboutUs AboutUs { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var aboutUs = new Domain.Models.AboutUs.AboutUs()
            {
                Text = AboutUs.Text,
                IsDelete = false
            };
            _aboutUs.Insert(aboutUs);
            return RedirectToPage("Index");
        }
    }
}
