using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace WarCatalog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ModelDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=VehiclesCatalog}/{action=TanksCatalogPage}");

                endpoints.MapControllerRoute(
                    name: "PlanesViewPage",
                    pattern: "/VehiclesCatalog/PlanesCatalogPage",
                    defaults: new { controller = "VehiclesCatalog", action = "PlanesCatalogPage" });

                endpoints.MapControllerRoute(
                    name: "HelicoptersViewPage",
                    pattern: "/VehiclesCatalog/HelicoptersCatalogPage",
                    defaults: new { controller = "VehiclesCatalog", action = "HelicoptersCatalogPage" });

                endpoints.MapControllerRoute(
                    name: "BMPViewPage",
                    pattern: "/VehiclesCatalog/BMPCatalogPage",
                    defaults: new { controller = "VehiclesCatalog", action = "BMPCatalogPage" });

                endpoints.MapControllerRoute(
                    name: "VehicleViewPage",
                    pattern: "/VehiclesCatalog/VehicleViewPage/{id}",
                    defaults: new { controller = "VehiclesCatalog", action = "VehicleViewPage" });

                endpoints.MapControllerRoute(
                   name: "VehicleAdditionPage",
                   pattern: "/VehicleAddition",
                   defaults: new { controller = "VehicleAddition", action = "VehicleAdditionPage" });

                endpoints.MapControllerRoute(
                    name: "VehicleAddButton",
                    pattern: "/VehicleAddition/VehicleAddButton",
                    defaults: new { controller = "VehicleAddition", action = "VehicleAddButton" });

                endpoints.MapControllerRoute(
                    name: "DeleteVehicle",
                    pattern: "/VehiclesCatalog/DeleteVehicle/{id}/{typeID}",
                    defaults: new { controller = "VehiclesCatalog", action = "DeleteVehicle" });
            });
        }
    }
}
