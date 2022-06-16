using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendingMachine.App.Models;
using VendingMachine.App.Stores;
using VendingMachine.App.ViewModels;

namespace VendingMachine.App.Commands
{
    public class PrepareOrderCommand : ICommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ProductsListingViewModel _productsListingViewModel;
        public PrepareOrderCommand(ModalNavigationStore modalNavigationStore, ProductsListingViewModel productsListingViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            _productsListingViewModel = productsListingViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ICommand backToHomeCommand = new BackFromModalCommand(_modalNavigationStore);
            OrderPageViewModel orderViewModel = new OrderPageViewModel(null, backToHomeCommand)
            {
                ImageName = _productsListingViewModel.SelectedProductsListingItemViewModel.ImageName,
                ProductName = _productsListingViewModel.SelectedProductsListingItemViewModel.ProductName,
            };
            _modalNavigationStore.CurrentViewModel = orderViewModel;
        }
    }
}
