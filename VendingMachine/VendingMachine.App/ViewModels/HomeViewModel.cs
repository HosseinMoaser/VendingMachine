using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendingMachine.App.Stores;

namespace VendingMachine.App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ProductsListingViewModel ProductsListingViewModel { get; }
        public ProductDetailViewModel ProductDetailViewModel { get; }
        ICommand PrepareOrderCommand { get; }

        public HomeViewModel(SelectedProductStore _selectedProductStore)
        {
            ProductDetailViewModel = new ProductDetailViewModel(_selectedProductStore);
            ProductsListingViewModel = new ProductsListingViewModel(_selectedProductStore);
        }
    }
}
