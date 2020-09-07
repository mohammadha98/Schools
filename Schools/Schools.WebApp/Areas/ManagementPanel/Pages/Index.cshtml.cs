using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;

namespace Schools.WebApp.Areas.ManagementPanel.Pages
{
    [PermissionsChecker(1)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
