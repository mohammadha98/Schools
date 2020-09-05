using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.AboutUs;
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
        public Domain.Models.AboutUs.AboutUs aboutUs { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var abouus = new Domain.Models.AboutUs.AboutUs()
            {
                Text = aboutUs.Text
            };
            _aboutUs.Insert(abouus);
            return RedirectToPage("Index");
        }
    }
}
