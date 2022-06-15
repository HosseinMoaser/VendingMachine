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

        public App()
        {
            _selectedProductStore = new SelectedProductStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.DataContext = new MainWindowViewModel(_selectedProductStore);
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
