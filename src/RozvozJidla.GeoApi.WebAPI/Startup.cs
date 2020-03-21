using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RozvozJidla.GeoApi.Common.Configuration;
using RozvozJidla.GeoApi.Common.Models;
using RozvozJidla.GeoApi.Common.Orchestrations;
using RozvozJidla.GeoApi.Common.Repository;
using RozvozJidla.GeoApi.Orchestration.Orchestrations;
using RozvozJidla.GeoApi.Orchestration.Repository;
using RozvozJidla.GeoApi.WebAPI.Configuration;

namespace RozvozJidla.GeoApi.WebAPI
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
            services.AddControllers();
            services.AddSingleton(typeof(IConfigurationResolver<>), typeof(ConfigurationResolver<>));
            services.AddScoped<IDeliveryAreaRepository, DeliveryAreaRepository>();
            services.AddScoped<IDeliveryProvidersCache, DeliveryProvidersCacheRepository>();
            services.AddSingleton<IDeliveryProvidersCache, DeliveryProvidersCacheRepository>();
            services.AddScoped<IDeliveryAreaOrchestration, DeliveryAreaOrchestration>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
