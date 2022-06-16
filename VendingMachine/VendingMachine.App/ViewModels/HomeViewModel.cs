using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendingMachine.App.Commands;
using VendingMachine.App.Stores;

namespace VendingMachine.App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ProductsListingViewModel ProductsListingViewModel { get; }
        public ProductDetailViewModel ProductDetailViewModel { get; }
        public ICommand PrepareOrderCommand { get; }

        public HomeViewModel(SelectedProductStore _selectedProductStore, ModalNavigationStore modalNavigationStore)
        {
            ProductDetailViewModel = new ProductDetailViewModel(_selectedProductStore);
            ProductsListingViewModel = new ProductsListingViewModel(_selectedProductStore);
            PrepareOrderCommand = new PrepareOrderCommand(modalNavigationStore);
        }
    }
}
