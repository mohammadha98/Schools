﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            return _context.Cities.Include(s => s.Areas);

        }

        public IEnumerable<Area> GetAllAreas()
        {
            return _context.Areas;

        }

        public Shire GetShireById(int shireId)
        {
            return _context.Shires.SingleOrDefault(s => s.ShireId == shireId);
        }

        public City GetCityById(int cityId)
        {
            return _context.Cities.SingleOrDefault(s => s.CityId == cityId);

        }

        public Area GetAreaById(int areaId)
        {
            return _context.Areas.SingleOrDefault(s => s.AreaId == areaId);

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

        public void AddArea(Area area)
        {

            _context.Areas.Add(area);
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

        public void EditArea(Area area)
        {
            _context.Areas.Update(area);
            _context.SaveChanges();
        }
    }
}