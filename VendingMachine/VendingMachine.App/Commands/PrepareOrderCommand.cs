using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
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
            BaseProductServices productServices = GetService(_productsListingViewModel.SelectedProductsListingItemViewModel.ProductName);
            OrderPageViewModel orderViewModel = new OrderPageViewModel(cancelOrderCommand, backToHomeCommand, productServices)
            {
                ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() +
                _productsListingViewModel.SelectedProductsListingItemViewModel.ImageName, UriKind.Relative)),
                ProductName = _productsListingViewModel.SelectedProductsListingItemViewModel.ProductName,
                Steps = GetSteps(_productsListingViewModel.SelectedProductsListingItemViewModel.ProductName),
                IsCancelButtonVisible = true
            };
            _modalNavigationStore.CurrentViewModel = orderViewModel;
        }


        private ObservableCollection<string> GetSteps(string productName)
        {
            switch (productName.ToLower())
            {
                case "hot chocolate":
                    return new ObservableCollection<string>()  { "Boil Water", "Add drinking chocolate to cup", "Add water" };
                case "lemon tea":
                    return new ObservableCollection<string>() { "Boil Water", "Add water" , "Steep tea bag", "Add lemon" };
                case "white coffee":
                    return new ObservableCollection<string>() { "Boil Water", "Add sugar", "Add coffee granules ", "Add water", "Add milk"};
                case "iced coffee":
                    return new ObservableCollection<string>() { "Crush Ice", "Add ice to blender", "Add coffee syrup to blender", "Blend ingredients", "Add ingredients" };
                default:
                    return new ObservableCollection<string>() { "Boil Water", "•	Add drinking chocolate to cup", "•	Add water" };
            }
        }

        private BaseProductServices GetService(string productName)
        {
            switch (productName.ToLower())
            {
                case "hot chocolate":
                    return new HotChocolateServices();
                case "lemon tea":
                    return new LemonTeaServices();
                case "white coffee":
                    return new WhiteCoffeeServices();
                case "iced coffee":
                    return new IcedCoffeeServices();
                default:
                    return new BaseProductServices();
            }
        }

    
    }
}
