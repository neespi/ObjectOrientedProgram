using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bridges.ApplicationServices.GetBridgesPointListUseCase;
using Bridges.ApplicationServices.Repositories;
using Bridges.DomainObjects.Ports;
using Bridges.DomainObjects;
using System.Collections.Generic;

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
            services.AddScoped<InMemoryBridgesPointRepository>(x => new InMemoryBridgesPointRepository(
                new List<BridgesPoint> {
                    new BridgesPoint() 
                    { 
                        Id = 1, 
                        Name = "Мост пешеходный «1905 года»", 
                        CrossRiver = "пруд в парке стадиона Красная Пресня", 
                      
                    },
                    new BridgesPoint()
                    {
                       Id = 1, 
                        Name = "Мост пешеходный «Андреевский»", 
                        CrossRiver = "река Москва", 
                    },
                    new BridgesPoint()
                    {
                        Id = 1, 
                        Name = "Мост пешеходный «Балочный»", 
                        CrossRiver = "река Сетунь", 
                    }
            }));
            services.AddScoped<IReadOnlyBridgesPointRepository>(x => x.GetRequiredService<InMemoryBridgesPointRepository>());
            services.AddScoped<IBridgesPointRepository>(x => x.GetRequiredService<InMemoryBridgesPointRepository>());

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
