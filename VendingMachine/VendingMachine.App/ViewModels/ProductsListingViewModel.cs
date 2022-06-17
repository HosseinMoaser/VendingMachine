using System.Collections.Generic;
using System.Collections.ObjectModel;
using VendingMachine.App.Stores;
using VendingMachine.Domain.Models;

namespace VendingMachine.App.ViewModels
{
    public class ProductsListingViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ProductsListingItemViewModel> _productsListingItemViewModels;
        private readonly SelectedProductStore _selectedProductStore;

        public IEnumerable<ProductsListingItemViewModel> ProductsListingItemViewModels => _productsListingItemViewModels;

        private ProductsListingItemViewModel _selectedProductsListingItemViewModel;

        public ProductsListingItemViewModel SelectedProductsListingItemViewModel
        {
            get { return _selectedProductsListingItemViewModel; }
            set
            {
                _selectedProductsListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedProductsListingItemViewModel));
                _selectedProductStore.SelectedProduct = _selectedProductsListingItemViewModel?.Product;
            }
        }


        public ProductsListingViewModel(SelectedProductStore selectedProductStore)
        {
            _productsListingItemViewModels = new ObservableCollection<ProductsListingItemViewModel>();
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("Hot Chocolate", "3.20$", "Cold", "10 sec", "/Images/hot_chocolate.jpg")));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("White Coffee", "2.50$", "Hot", "14 sec", "/Images/white_coffee.jpg")));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("Lemon Tea", "4.10$", "Cold", "18 sec", "/Images/lemon_tea.jpg")));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("Iced Coffee", "3.40$", "Hot", "16 sec", "/Images/iced_coffee.png")));
            _selectedProductStore = selectedProductStore;
        }

    }
}
