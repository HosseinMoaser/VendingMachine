using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.App.Stores;

namespace VendingMachine.App.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public HomeViewModel HomeViewModel { get; set; }

        public MainWindowViewModel(SelectedProductStore _selectedProductStore)
        {
            HomeViewModel = new HomeViewModel(_selectedProductStore);
        }
    }
}
