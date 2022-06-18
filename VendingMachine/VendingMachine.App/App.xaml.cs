using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VendingMachine.App.HostBuilders;
using VendingMachine.App.State;
using VendingMachine.App.ViewModels;
using VendingMachine.DataLayer;
using VendingMachine.DataLayer.Models;
using VendingMachine.Domain.Repositories;
using VendingMachine.Domain.Services;
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
                AddDBContext().AddStores().AddViewModels()
                .AddProductsServices()
                .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IAuthenticationServices, AuthenticationServices>();
                services.AddSingleton<IAccountServices, AccountServices>();
                services.AddSingleton<IAccountServices, AccountServices>();
                services.AddSingleton<Authenticator>();
                services.AddScoped<DataServices>();
                services.AddSingleton<MainWindow>((services) => new MainWindow()
                {
                    DataContext = services.GetRequiredService<MainWindowViewModel>()
                });
            }).Build();

        }
        protected async override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            // Apply migration using host services
            VendingMachineDBContextFactory contextFactory = _host.Services.GetRequiredService<VendingMachineDBContextFactory>();
            IAuthenticator authenticator = _host.Services.GetRequiredService<Authenticator>();

            using (VendingMachineDBContext context = contextFactory.CreateDBContext())
            {
                context.Database.Migrate();
            }

            await AddSampleUser();


            if (await authenticator.Login("HosseinMsr", "12345"))
            {
                MainWindow = _host.Services.GetRequiredService<MainWindow>();
                ((MainWindowViewModel)MainWindow.DataContext).Authenticator = authenticator;
                MainWindow.Show();
                base.OnStartup(e);
            }
            else
            {
                MessageBox.Show("Username Or Password Are Wrong...!");
                Current.Shutdown();
            }

        }

        private async Task AddSampleUser()
        {
            IDataServices dataServices = _host.Services.GetRequiredService<DataServices>();
            IEnumerable<User> users = await dataServices.GetAllUsers();
            if (!users.Any())
                await dataServices.Create(new User() { UserName = "HosseinMsr", Passwword = "12345" });
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
