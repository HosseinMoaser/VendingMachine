using System;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
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
                ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() +
                _productsListingViewModel.SelectedProductsListingItemViewModel.ImageName, UriKind.Relative)),
                ProductName = _productsListingViewModel.SelectedProductsListingItemViewModel.ProductName,
            };
            _modalNavigationStore.CurrentViewModel = orderViewModel;
        }
    }
}
