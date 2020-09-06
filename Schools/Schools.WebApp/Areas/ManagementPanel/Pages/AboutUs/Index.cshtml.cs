using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Repository.InterfaceRepository.AboutUsRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.AboutUs
{
    [PermissionsChecker(1)]
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