using System.Collections.Generic;
using Schools.Domain.Models.Schools.Locations;

namespace Schools.Application.Service.Interfaces.Locations
{
    public interface ILocationService
    {
        List<Shire> GetAllShire();
        List<City> GetAllCityByShireId(int shireId);
   
        bool IsShireHasASchool(int shireId);
        bool IsCityHasASchool(int cityId);
    }
}