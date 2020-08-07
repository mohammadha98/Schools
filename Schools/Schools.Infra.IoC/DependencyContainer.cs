using Microsoft.Extensions.DependencyInjection;
using Schools.Domain.Repository.InterfaceRepository;
using Schools.Application.Service.Interfaces;
using Schools.Application.Service.Services.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Repository.ServiceRepository.Schools;

namespace Schools.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //From Application Layer

            #region School
            service.AddScoped<ISchoolService, SchoolService>();
            service.AddScoped<ISchoolRepository, SchoolRepository>();
            #endregion

            //From Infra Data Layer




            #region Schools
            service.AddScoped<ISchoolGroupsRepository, SchoolGroupsRepository>();
            service.AddScoped<ISchoolGroupsService, SchoolGroupsService>();
            #endregion


        }
    }
}
