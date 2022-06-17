using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VendingMachine.App.Stores;
using VendingMachine.DataLayer;

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
    }
}
