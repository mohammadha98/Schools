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
    public class EditModel : PageModel
    {
        private ILocationRepository _location;

        public EditModel(ILocationRepository location)
        {
            _location = location;
        }
        [BindProperty]
        public City City { get; set; }
        public void OnGet(int cityId,int shireId)
        {
            var city = _location.GetCityById(cityId);
            if (city==null || city.ShireId != shireId)
                Response.Redirect("/ManagementPanel/Locations/Cities/"+shireId);

            City = city;
        }

        public IActionResult OnPost(int cityId, int shireId)
        {
            City.ShireId = shireId;
            City.CityId = cityId;
            City.IsDelete = false;
            if (!ModelState.IsValid)
            {
                return Redirect("/ManagementPanel/Locations/Cities/Edit/" + cityId + "/" + shireId);
            }
            _location.EditCity(City);
            return Redirect("/ManagementPanel/Locations/Cities/"+ shireId);

        }
    }
}
