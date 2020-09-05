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
    public class IndexModel : PageModel
    {
        private IAboutUsRepository _aboutUs;
        public IndexModel(IAboutUsRepository aboutUs)
        {
            _aboutUs = aboutUs;
        }
        [BindProperty]
        public IEnumerable<Domain.Models.AboutUs.AboutUs> aboutUs { get; set; }
        public void OnGet()
        {
            aboutUs= _aboutUs.GetAllAboutUs();
        }
    }
}