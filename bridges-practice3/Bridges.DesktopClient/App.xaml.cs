using Microsoft.Extensions.DependencyInjection;
using Bridges.ApplicationServices.GetBridgesPointListUseCase;
using Bridges.ApplicationServices.Ports.Cache;
using Bridges.ApplicationServices.Repositories;
using Bridges.DesktopClient.InfrastructureServices.ViewModels;
using Bridges.DomainObjects;
using Bridges.DomainObjects.Ports;
using Bridges.InfrastructureServices.Cache;
using Bridges.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bridges.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<BridgesPoint>, DomainObjectsMemoryCache<BridgesPoint>>();
            services.AddSingleton<NetworkBridgesPointRepository>(
                x => new NetworkBridgesPointRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<BridgesPoint>>())
            );
            services.AddSingleton<CachedReadOnlyBridgesPointRepository>(
                x => new CachedReadOnlyBridgesPointRepository(
                    x.GetRequiredService<NetworkBridgesPointRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<BridgesPoint>>()
                )
            );
            services.AddSingleton<IReadOnlyBridgesPointRepository>(x => x.GetRequiredService<CachedReadOnlyBridgesPointRepository>());
            services.AddSingleton<IGetBridgesPointListUseCase, GetBridgesPointListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
