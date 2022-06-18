using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VendingMachine.App.Stores;
using VendingMachine.App.ViewModels;
using VendingMachine.DataLayer;
using VendingMachine.Domain.Repositories;
using VendingMachine.Domain.Services;

namespace VendingMachine.App.HostBuilders
{
    public static class HostBuilderExtentions
    {
        public static IHostBuilder AddDBContext(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                string connectionString = "Data Source = VendingMachineDB.db";
                services.AddSingleton<VendingMachineDBContextFactory>();
                services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);                
            });
            return hostBuilder;
        }

        public static IHostBuilder AddStores(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<ModalNavigationStore>();
                services.AddSingleton<SelectedProductStore>();
            });
            return hostBuilder;
        }

        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindowViewModel>();
                services.AddTransient<HomeViewModel>();
            });
            return hostBuilder;
        }

        public static IHostBuilder AddProductsServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IBaseProductServices,BaseProductServices>();
                services.AddSingleton<IHotChocolateServices,HotChocolateServices>();
                services.AddSingleton<IIcedCoffeeServices,IcedCoffeeServices>();
                services.AddSingleton<ILemonTeaServices,LemonTeaServices>();
                services.AddSingleton<IWhiteCoffeeServices,WhiteCoffeeServices>();

            });
            return hostBuilder;
        }
    }
}

