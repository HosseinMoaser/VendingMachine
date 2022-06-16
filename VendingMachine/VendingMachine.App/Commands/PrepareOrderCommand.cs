using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendingMachine.App.Stores;
using VendingMachine.App.ViewModels;

namespace VendingMachine.App.Commands
{
    public class PrepareOrderCommand : ICommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public PrepareOrderCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            OrderPageViewModel orderViewModel = new OrderPageViewModel();
            _modalNavigationStore.CurrentViewModel = orderViewModel;
        }
    }
}
