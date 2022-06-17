using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using VendingMachine.App.HostBuilders;
using VendingMachine.App.Stores;
using VendingMachine.App.ViewModels;
using VendingMachine.DataLayer;

namespace VendingMachine.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().
                AddDBContext().AddStores()
                .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindowViewModel>();
                services.AddTransient<HomeViewModel>((services) => new HomeViewModel(services.GetRequiredService<SelectedProductStore>(),
                    services.GetRequiredService<ModalNavigationStore>()));

                services.AddSingleton<MainWindow>((services) => new MainWindow()
                {
                    DataContext = services.GetRequiredService<MainWindowViewModel>()
                });
            }).Build();

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            // Apply migration using host services
            VendingMachineDBContextFactory contextFactory = _host.Services.GetRequiredService<VendingMachineDBContextFactory>();
            using (VendingMachineDBContext context = contextFactory.CreateDBContext())
            {
                context.Database.Migrate();
            }


            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
