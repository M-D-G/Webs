using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NarushPDD.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using NarushPDD.ApplicationServices.GetRoadPDDListUseCase;
using NarushPDD.ApplicationServices.Ports.Gateways.Database;
using NarushPDD.ApplicationServices.Repositories;
using NarushPDD.DomainObjects.Ports;

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
            services.AddDbContext<PDDContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "NarushPDD.db")}")
            );

            services.AddScoped<IPDDDatabaseGateway, PDDEFSqliteGateway>();

            services.AddScoped<DbRoadPDDRepository>();
            services.AddScoped<IReadOnlyRoadPDDRepository>(x => x.GetRequiredService<DbRoadPDDRepository>());
            services.AddScoped<IRoadPDDRepository>(x => x.GetRequiredService<DbRoadPDDRepository>());


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
