using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Domain.Models.Schools.Locations;
using Schools.Domain.Repository.InterfaceRepository.Locations;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Locations.Cities
{
    public class IndexModel : PageModel
    {
        private ILocationService _location;
        private ILocationRepository _repository;

        public IndexModel(ILocationService location, ILocationRepository repository)
        {
            _location = location;
            _repository = repository;
        }

        public List<City> Cities { get; set; }
        public void OnGet(int shireId)
        {
            var shire = _repository.GetShireById(shireId);

            if (shire == null)
                Response.Redirect("/ManagementPanel/Locations");

            ViewData["shire"] = shire;
            Cities = _location.GetAllCityByShireId(shireId);
        }
    }
}
