using System.Collections.Generic;
using Schools.Domain.Models.Schools.Locations;

namespace Schools.Domain.Repository.InterfaceRepository.Locations
{
    public interface ILocationRepository
    {
        IEnumerable<Shire> GetAllShires();
        IEnumerable<City> GetAllCities();
      
        Shire GetShireById(int shireId);
        City GetCityById(int cityId);
       
        void AddShire(Shire shire);
        void AddCity(City city);
        
        void EditShire(Shire shire);
        void EditCity(City city);
        
        void DeleteShire(Shire shire);
        void DeleteCity(City city);
    }
}