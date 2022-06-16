using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VendingMachine.App.Stores;
using VendingMachine.App.ViewModels;

namespace VendingMachine.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedProductStore _selectedProductStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _selectedProductStore = new SelectedProductStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            HomeViewModel homeViewModel = new HomeViewModel(_selectedProductStore, _modalNavigationStore);
            MainWindow.DataContext = new MainWindowViewModel(homeViewModel, _modalNavigationStore);
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
