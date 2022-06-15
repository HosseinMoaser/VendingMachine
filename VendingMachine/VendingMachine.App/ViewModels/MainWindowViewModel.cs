using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.App.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public HomeViewModel HomeViewModel { get; set; }

        public MainWindowViewModel()
        {
            HomeViewModel = new HomeViewModel();
        }
    }
}
