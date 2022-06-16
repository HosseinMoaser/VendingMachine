using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using VendingMachine.App.Models;

namespace VendingMachine.App.ViewModels
{
    public class ProductsListingItemViewModel : BaseViewModel
    {
        public Product Product { get; }     
        public string ProductName => Product.ProductName;
        public string ImageName =>  Product.ImageName;       
        public string ProductPrice => Product.ProductPrice;
        public string ProductCategory => Product.ProductCategory;
        public string EstimatedTime => Product.EstimatedTime;

        public ProductsListingItemViewModel(Product product)
        {
            Product = product;
        }
    }
}
