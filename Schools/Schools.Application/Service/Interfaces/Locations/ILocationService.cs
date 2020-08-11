using System.Collections.Generic;
using Schools.Domain.Models.Schools.Locations;

namespace Schools.Application.Service.Interfaces.Locations
{
    public interface ILocationService
    {
        List<Shire> GetAllShire();
        List<City> GetAllCityByShireId(int shireId);
        List<Area> GetAllAreaByCityId(int cityId);
        bool IsShireHasASchool(int shireId);
        bool IsCityHasASchool(int cityId);
    }
}