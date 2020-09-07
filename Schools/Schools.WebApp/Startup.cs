using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schools.Infra.Data.Context;
using Schools.Infra.IoC;
using System;

namespace Schools.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
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

            #region Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });
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

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

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
