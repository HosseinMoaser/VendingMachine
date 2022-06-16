using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.App.ViewModels;

namespace VendingMachine.App.Stores
{
    public class ModalNavigationStore : BaseViewModel
    {
        private BaseViewModel _currentViewModel;

        public bool IsOpen => CurrentViewModel != null;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            { 
                _currentViewModel = value; 
                CurrentViewModelChanged?.Invoke();
            }
        }

        public event Action CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }
    }
}
