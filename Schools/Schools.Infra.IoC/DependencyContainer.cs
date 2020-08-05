using Microsoft.Extensions.DependencyInjection;
using Schools.Application.Interfaces;
using Schools.Domain.Interfaces;
using Schools.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Schools.Application.Services;
using Schools.Infra.Data.Repository.ServiceRepository;

namespace Schools.Infra.IoC
{
   public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //From Application Layer

            service.AddScoped<ITestService,TestService>();


            //From Infra Data Layer

            service.AddScoped<ITestRepository, TestRepository>();




        }
    }
}
