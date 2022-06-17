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
    public class CancelOrderCommand : ICommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public CancelOrderCommand(ModalNavigationStore modalNavigationStore)
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
            BaseViewModel viewModel = (OrderPageViewModel)_modalNavigationStore.CurrentViewModel;
            OrderPageViewModel orderPageViewModel = viewModel as OrderPageViewModel;
            orderPageViewModel.IsCanceled = true;
        }


    }
}
