using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Aircrafts.Queries.GetAircraftList;
using Application.Airports.Queries.GetAirportsList;
using Application.Flights.Commands.CreateFlight;
using Application.Flights.Commands.Services;
using Application.Flights.Commands.UpdateFlight;
using Application.Flights.Queries.GetFlightDetail;
using Application.Flights.Queries.GetFlightsList;
using Application.Interfaces;
using Infrastructure.Aircrafts;
using Infrastructure.Airports;
using Infrastructure.Common;
using Infrastructure.Flights;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Flights.Models.Factory;

namespace Presentation
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
            //Repositories
            services.AddScoped<IAirportRepository, AirportsRepository>();
            services.AddScoped<IAircraftRepository, AircraftRepository>();
            services.AddScoped<IFlightRepository, FlightsRepository>();
            services.AddScoped<IFlightRepositoryFacade, FlightRepositoryFacade>();

            //Queries
            services.AddScoped<IGetAirportsListQuery, GetAirportsListQuery>();
            services.AddScoped<IGetAircraftListQuery, GetAircraftsListQuery>();
            services.AddScoped<IGetFlightListQuery, GetFlightsListQuery>();
            services.AddScoped<IGetFlightDetailQuery, GetFlightDetailQuery>();

            //Commands
            services.AddScoped<ICreateFlightCommand, CreateFlightCommand>();
            services.AddScoped<IUpdateFlightCommand, UpdateFlightCommand>();

            //Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUpsertFlightViewModelFactory, UpsertFlightViewModelFactory>();

            services.AddDbContext<CustomContext>(opt => opt
                .UseInMemoryDatabase("FlightsDB")
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            EnsureDBInitialized(app);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }

        private void EnsureDBInitialized(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CustomContext>();
                context.Database.EnsureCreated();
            }
        }

    }
}
