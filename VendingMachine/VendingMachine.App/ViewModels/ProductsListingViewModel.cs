using System.Collections.Generic;
using System.Collections.ObjectModel;
using VendingMachine.App.Stores;
using VendingMachine.Domain.Models;
using static VendingMachine.App.ViewModels.ProductsListingItemViewModel;

namespace VendingMachine.App.ViewModels
{
    public class ProductsListingViewModel : BaseViewModel
    {       
        private readonly ObservableCollection<ProductsListingItemViewModel> _productsListingItemViewModels;
        private readonly SelectedProductStore _selectedProductStore;

        public IEnumerable<ProductsListingItemViewModel> ProductsListingItemViewModels => _productsListingItemViewModels;

        private ProductsListingItemViewModel _selectedProductsListingItemViewModel;

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        public ProductsListingItemViewModel SelectedProductsListingItemViewModel
        {
            get { return _selectedProductsListingItemViewModel; }
            set
            {
                _selectedProductsListingItemViewModel = value;
                if (_selectedProductsListingItemViewModel != null)
                    IsSelected = true;
                else
                    IsSelected = false;
                OnPropertyChanged(nameof(SelectedProductsListingItemViewModel));
                _selectedProductStore.SelectedProduct = _selectedProductsListingItemViewModel?.Product;
            }
        }


        public ProductsListingViewModel(SelectedProductStore selectedProductStore)
        {
            _productsListingItemViewModels = new ObservableCollection<ProductsListingItemViewModel>();
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("Hot Chocolate", "3.20$", "Cold", "10 sec", "/Images/hot_chocolate.jpg")));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("White Coffee", "2.50$", "Hot", "14 sec", "/Images/white_coffee.jpg")));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel( new Product("Lemon Tea", "4.10$", "Cold", "18 sec", "/Images/lemon_tea.jpg")));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("Iced Coffee", "3.40$", "Hot", "16 sec", "/Images/iced_coffee.png")));
            _selectedProductStore = selectedProductStore;
        }

    }
}
