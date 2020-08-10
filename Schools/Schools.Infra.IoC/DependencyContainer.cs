using Microsoft.Extensions.DependencyInjection;
using Schools.Domain.Repository.InterfaceRepository;
using Schools.Application.Service.Interfaces;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Service.Services.Locations;
using Schools.Application.Service.Services.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Repository.ServiceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Domain.Repository.InterfaceRepository.Locations;
using Schools.Infra.Data.Repository.ServiceRepository.BlogRepositoris;
using Schools.Infra.Data.Repository.ServiceRepository.Locations;

namespace Schools.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //From Application Layer

            #region Locations

            service.AddScoped<ILocationService, LocationService>();

            #endregion
            #region School
            service.AddScoped<ISchoolService, SchoolService>();
            service.AddScoped<ISchoolGroupsService, SchoolGroupsService>();
            service.AddScoped<ISchoolGalleryService, SchoolGalleryService>();
            #endregion

            //From Infra Data Layer

            #region Locations
            service.AddScoped<ILocationRepository, LocationRepository>();
            #endregion

            #region Schools
            service.AddScoped<ISchoolGroupsRepository, SchoolGroupsRepository>();
            service.AddScoped<ISchoolRepository, SchoolRepository>();
            service.AddScoped<ISchoolGalleryRepository, SchoolGalleryRepository>();
            #endregion

            #region Blogs
            service.AddScoped<IBlogRepository, BlogRepository>();
            service.AddScoped<IBlogGroupsRepository, BlogGroupRepositoy>();
            #endregion

        }
    }
}
