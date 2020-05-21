using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NarushPDD.ApplicationServices.GetRoadPDDListUseCase;
using NarushPDD.ApplicationServices.Repositories;
using NarushPDD.DomainObjects.Ports;
using NarushPDD.DomainObjects;
using System.Collections.Generic;

namespace NarushPDD.WebService
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
            services.AddScoped<InMemoryRoadPDDRepository>(x => new InMemoryRoadPDDRepository(
                new List<RoadPDD> {
                    new RoadPDD() 
                    { 
                        Id = 1,
                         Data ="20.01.2013", 
                        RecordedV="Общее количество зафиксированных - 5374",
                        RegisteredV="Общее количество оформленных - 2440",

    },
                    new RoadPDD()
                    {
                       Id = 2,
                        Data ="21.01.2013",
                        RecordedV="Общее количество зафиксированных - 25312",RegisteredV="Общее количество оформленных - 1551",
                    },
                    new RoadPDD()
                    {
                        Id = 3,
                         Data ="22.01.2013",
                        RecordedV="Общее количество зафиксированных - 29132",
                        RegisteredV="Общее количество оформленных - 2672",
                    }
            }));
            services.AddScoped<IReadOnlyRoadPDDRepository>(x => x.GetRequiredService<InMemoryRoadPDDRepository>());
            services.AddScoped<IRoadPDDRepository>(x => x.GetRequiredService<InMemoryRoadPDDRepository>());

            services.AddScoped<IGetRoadPDDListUseCase, GetRoadPDDListUseCase>();
                        
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
