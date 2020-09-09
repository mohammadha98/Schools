using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels;
using Schools.Application.ViewModels.SchoolsViewModels;

namespace Schools.WebApp.Areas.ManagementPanel.Pages
{
    [PermissionsChecker(1)]
    public class IndexModel : PageModel
    {
        private IAdminMainPageService _service;

        public IndexModel(IAdminMainPageService service)
        {
            _service = service;
        }

        public AdminMainPageViewModel PageViewModel { get; set; }
        public void OnGet()
        {
            PageViewModel = _service.GetDataForMainPage();
        }
    }
}
