using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.App.ViewModels
{
    public class ProductsListingViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ProductsListingItemViewModel> _productsListingItemViewModels;
        public IEnumerable<ProductsListingItemViewModel> ProductsListingItemViewModels => _productsListingItemViewModels;

        public ProductsListingViewModel()
        {
            _productsListingItemViewModels = new ObservableCollection<ProductsListingItemViewModel>();
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel("Coffee","avatar"));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel("Chocolate","avatar"));
            _productsListingItemViewModels.Add(new ProductsListingItemViewModel("Lemon Tea", "avatar"));

        }

    }
}
