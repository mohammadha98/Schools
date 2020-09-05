using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Repository.InterfaceRepository.AboutUsRepository;
using Schools.Infra.Data.Migrations;

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
        public Domain.Models.AboutUs.AboutUs aboutUs { get; set; }
        public void OnGet(int id)
        {
            var aboutus = _aboutUs.GetAbouUsById(id);
            aboutUs = aboutus;
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            var aboutus = _aboutUs.GetAbouUsById(id);
            aboutus.Text = aboutUs.Text;

            _aboutUs.Update(aboutus);
            return RedirectToPage("Index");
        }
    }
}
