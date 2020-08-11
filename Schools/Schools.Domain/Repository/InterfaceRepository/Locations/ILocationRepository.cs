using System.Collections.Generic;
using Schools.Domain.Models.Schools.Locations;

namespace Schools.Domain.Repository.InterfaceRepository.Locations
{
    public interface ILocationRepository
    {
        IEnumerable<Shire> GetAllShires();
        IEnumerable<City> GetAllCities();
        IEnumerable<Area> GetAllAreas();
        Shire GetShireById(int shireId);
        City GetCityById(int cityId);
        Area GetAreaById(int areaId);
        void AddShire(Shire shire);
        void AddCity(City city);
        void AddArea(Area area);
        void EditShire(Shire shire);
        void EditCity(City city);
        void EditArea(Area area);
        void DeleteShire(Shire shire);
        void DeleteCity(City city);
    }
}