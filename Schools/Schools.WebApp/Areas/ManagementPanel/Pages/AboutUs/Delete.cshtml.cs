using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.AboutUsRepository;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.AboutUs
{
    public class DeleteModel : PageModel
    {
        private IAboutUsRepository _aboutUs;
        public DeleteModel(IAboutUsRepository aboutUs)
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

        public IActionResult OnPost()
        {
            var aboutus = _aboutUs.GetAbouUsById(aboutUs.AboutUsId);
            aboutus.IsDelete = true;

            _aboutUs.Update(aboutus);
            return RedirectToPage("index");
        }
    }
}
