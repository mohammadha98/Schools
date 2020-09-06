using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools.Locations;
using Schools.Domain.Repository.InterfaceRepository.Locations;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Locations
{
    [PermissionsChecker(18)]
    public class AddModel : PageModel
    {
        private ILocationRepository _location;

        public AddModel(ILocationRepository location)
        {
            _location = location;
        }
        [BindProperty]
        public Shire Shire { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Shire.IsDelete = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _location.AddShire(Shire);
            return RedirectToPage("Index");
        }
    }
}
