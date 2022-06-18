using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VendingMachine.App.ProductsTools;
using VendingMachine.App.Stores;
using VendingMachine.App.ViewModels;
using VendingMachine.Domain.Services;
using static VendingMachine.App.ViewModels.ProductsListingItemViewModel;

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
            ICommand cancelOrderCommand = new CancelOrderCommand(_modalNavigationStore);
            BaseProductServices productServices = ProductTools.GetService(_productsListingViewModel.SelectedProductsListingItemViewModel.ProductName);
            OrderPageViewModel orderViewModel = new OrderPageViewModel(cancelOrderCommand, backToHomeCommand, productServices)
            {
                ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() +
                _productsListingViewModel.SelectedProductsListingItemViewModel.ImageName, UriKind.Relative)),
                ProductName = _productsListingViewModel.SelectedProductsListingItemViewModel.ProductName,
                Steps = ProductTools.GetSteps(_productsListingViewModel.SelectedProductsListingItemViewModel.ProductName),
                IsCancelButtonVisible = true
            };
            _modalNavigationStore.CurrentViewModel = orderViewModel;
        }

    }
}
