using Microsoft.Extensions.DependencyInjection;
using NarushPDD.ApplicationServices.GetRoadPDDListUseCase;
using NarushPDD.ApplicationServices.Ports.Cache;
using NarushPDD.ApplicationServices.Repositories;
using NarushPDD.DesktopClient.InfrastructureServices.ViewModels;
using NarushPDD.DomainObjects;
using NarushPDD.DomainObjects.Ports;
using NarushPDD.InfrastructureServices.Cache;
using NarushPDD.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NarushPDD.DesktopClient
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
            services.AddSingleton<IDomainObjectsCache<RoadPDD>, DomainObjectsMemoryCache<RoadPDD>>();
            services.AddSingleton<NetworkRoadPDDRepository>(
                x => new NetworkRoadPDDRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<RoadPDD>>())
            );
            services.AddSingleton<CachedReadOnlyRoadPDDRepository>(
                x => new CachedReadOnlyRoadPDDRepository(
                    x.GetRequiredService<NetworkRoadPDDRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<RoadPDD>>()
                )
            );
            services.AddSingleton<IReadOnlyRoadPDDRepository>(x => x.GetRequiredService<CachedReadOnlyRoadPDDRepository>());
            services.AddSingleton<IGetRoadPDDListUseCase, GetRoadPDDListUseCase>();
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
