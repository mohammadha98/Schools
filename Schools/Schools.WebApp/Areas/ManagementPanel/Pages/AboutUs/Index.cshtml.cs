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
        private IAboutUsRepository _about;

        public IndexModel(IAboutUsRepository about)
        {
            _about = about;
        }
        
        public Domain.Models.AboutUs.AboutUs AboutUs { get; set; }
        public void OnGet()
        {
            AboutUs = _about.GetLast();
            
        }
    }
}