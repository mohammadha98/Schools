using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schools.Infra.Data.Context;
using Schools.Infra.IoC;

namespace Schools.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<SchoolsDbContext>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=Schools_DB;Integrated Security=true");
            });

            #region DependencyInjection
            //Dependency Injection In ./Infra.IoC/DependencyContainer.Cs

            RegisterServices(services);

            //Please Inject Your Dependencies in DependencyContainer.Cs
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region HandlerErrors

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/home/HandlerError");

            }
            app.UseStatusCodePagesWithReExecute("/Home/HandleError/{0}");
            #endregion



            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Intro}/{action=Index}/{id?}"
                    );
            });
        }

        //this Method send Dependency injection from DependencyConrainer.cs to StartUp.cs

        public static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
    }
}
