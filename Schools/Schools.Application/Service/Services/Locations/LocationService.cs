using System.Collections.Generic;
using System.Linq;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Domain.Models.Schools.Locations;
using Schools.Domain.Repository.InterfaceRepository.Locations;

namespace Schools.Application.Service.Services.Locations
{
    public class LocationService:ILocationService
    {
        private ILocationRepository _location;

        public LocationService(ILocationRepository location)
        {
            _location = location;
        }

        public List<Shire> GetAllShire()
        {
            return _location.GetAllShires().ToList();
        }

        public List<City> GetAllCityByShireId(int shireId)
        {
            return _location.GetAllCities().Where(c => c.ShireId == shireId).ToList();
        }

        public List<City> GetAllCityByShireTitle(string shireTitle)
        {
            return _location.GetAllCities().Where(c => c.Shire.ShireTitle == shireTitle).ToList();

        }


        public bool IsShireHasASchool(int shireId)
        {
            var shire = _location.GetShireById(shireId);
            return shire.Schools.Any();
        }

        public bool IsCityHasASchool(int cityId)
        {
            var city = _location.GetCityById(cityId);
            return city.Schools.Any();
        }
    }
}