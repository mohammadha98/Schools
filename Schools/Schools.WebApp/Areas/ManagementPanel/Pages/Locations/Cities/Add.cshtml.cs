using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Schools.Locations;
using Schools.Domain.Repository.InterfaceRepository.Locations;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Locations.Cities
{
    public class AddModel : PageModel
    {
        private ILocationRepository _location;

        public AddModel(ILocationRepository location)
        {
            _location = location;
        }
        [BindProperty]
        public City City { get; set; }
        public void OnGet(int shireId)
        {
        }

        public IActionResult OnPost(int shireId)
        {
            City.ShireId = shireId;
            City.IsDelete = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _location.AddCity(City);
            return Redirect("/ManagementPanel/Locations/Cities/" + shireId);
        }
    }
}
