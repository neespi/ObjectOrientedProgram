using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bridges.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using Bridges.ApplicationServices.GetBridgesPointListUseCase;
using Bridges.ApplicationServices.Ports.Gateways.Database;
using Bridges.ApplicationServices.Repositories;
using Bridges.DomainObjects.Ports;

namespace Bridges.WebService
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
            services.AddDbContext<BridgesContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "Bridges.db")}")
            );

            services.AddScoped<IBridgesDatabaseGateway, BridgesEFSqliteGateway>();

            services.AddScoped<DbBridgesPointRepository>();
            services.AddScoped<IReadOnlyBridgesPointRepository>(x => x.GetRequiredService<DbBridgesPointRepository>());
            services.AddScoped<IBridgesPointRepository>(x => x.GetRequiredService<DbBridgesPointRepository>());


            services.AddScoped<IGetBridgesPointListUseCase, GetBridgesPointListUseCase>();

            
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