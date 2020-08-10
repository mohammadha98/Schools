using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Domain.Models.Schools.Locations;
using Schools.Domain.Repository.InterfaceRepository.Locations;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Locations
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

        public List<Shire> Shires { get; set; }
        public void OnGet()
        {
            Shires = _location.GetAllShire();
        }

        public IActionResult OnGetDeleteShire(int shireId)
        {
            var shire = _repository.GetShireById(shireId);
            if (shire == null)
                return Content("NotFound");

            if (_location.IsShireHasASchool(shireId))
            {
                return Content("Error");
            }
            _repository.DeleteShire(shire);
            return Content("Deleted");
        }
        public IActionResult OnGetDeleteCity(int cityId)
        {
            var city = _repository.GetCityById(cityId);
            if (city == null)
                return Content("NotFound");

            if (_location.IsCityHasASchool(cityId))
            {
                return Content("Error");
            }
            _repository.DeleteCity(city);
            return Content("Deleted");
        }
    }
}
