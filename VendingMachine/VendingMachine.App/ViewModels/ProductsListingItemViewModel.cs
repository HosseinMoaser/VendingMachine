using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.App.ViewModels
{
    public class ProductsListingItemViewModel : BaseViewModel
    {
        public string ProductName { get;}
        public string ImageAddress { get;}

        public ProductsListingItemViewModel(string productName, string imageAddress)
        {
            ProductName = productName;
            ImageAddress = imageAddress;
        }
    }
}
