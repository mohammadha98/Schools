using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Schools.Locations;
using Schools.Domain.Repository.InterfaceRepository.Locations;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Locations
{
    public class LocationRepository:ILocationRepository
    {
        private SchoolsDbContext _context;

        public LocationRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Shire> GetAllShires()
        {
            return _context.Shires.Include(s => s.Cities);
        }

    
        public IEnumerable<City> GetAllCities()
        {
            return _context.Cities.Include(c=>c.Shire);

        }

       

        public Shire GetShireById(int shireId)
        {
            return _context.Shires.Include(s=>s.Schools).SingleOrDefault(s => s.ShireId == shireId);
        }

        public Shire GetShireByTitle(string shireTitle)
        {
            return _context.Shires.Include(s => s.Schools).SingleOrDefault(s => s.ShireTitle == shireTitle);
        }

        public Shire GetShireByEnglishName(string englishName)
        {
            return _context.Shires.Include(s => s.Schools).SingleOrDefault(s => s.EnglishName == englishName);

        }

        public City GetCityById(int cityId)
        {
            return _context.Cities.Include(s => s.Schools).SingleOrDefault(s => s.CityId == cityId);

        }


        public void AddShire(Shire shire)
        {
            _context.Shires.Add(shire);
            _context.SaveChanges();
        }

        public void AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

     

        public void EditShire(Shire shire)
        {
            _context.Shires.Update(shire);
            _context.SaveChanges();
        }

        public void EditCity(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }

       

        public void DeleteShire(Shire shire)
        {
            shire.IsDelete = true;
           EditShire(shire);

        }

        public void DeleteCity(City city)
        {
            city.IsDelete = true;
            EditCity(city);
        }
    }
}