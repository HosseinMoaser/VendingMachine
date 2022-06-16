using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VendingMachine.App.Stores;
using VendingMachine.App.ViewModels;
using VendingMachine.DataLayer;
using VendingMachine.Domain.Services;

namespace VendingMachine.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedProductStore _selectedProductStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly VendingMachineDBContextFactory _contextFactory;
        private readonly DataServices _dataServices;

        public App()
        {
            string connectionString = "Data Source = VendingMachineDB.db";
            _modalNavigationStore = new ModalNavigationStore();
            _selectedProductStore = new SelectedProductStore();
            _contextFactory = new VendingMachineDBContextFactory(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
            _dataServices = new DataServices(_contextFactory);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using(VendingMachineDBContext context = _contextFactory.CreateDBContext())
            {
                context.Database.Migrate();
            }
            MainWindow = new MainWindow();
            HomeViewModel homeViewModel = new HomeViewModel(_selectedProductStore, _modalNavigationStore);
            MainWindow.DataContext = new MainWindowViewModel(homeViewModel, _modalNavigationStore);
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
