using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.App.Models;
using VendingMachine.App.Stores;

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
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("Hot Chocolate", "50$","Cold","10 sec","avatar")));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("Coffee", "40$", "Hot", "14 sec", "avatar")));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("Iced Tea", "55$", "Cold", "18 sec", "avatar")));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel(new Product("Lemon Tea", "34$", "Hot", "16 sec", "avatar")));
            _selectedProductStore = selectedProductStore;
        }

    }
}
