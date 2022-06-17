using System;
using System.IO;
using System.Windows.Media.Imaging;
using VendingMachine.Domain.Models;

namespace VendingMachine.App.ViewModels
{
    public class ProductsListingItemViewModel : BaseViewModel
    {
        public Product Product { get; }
        public string ProductName => Product.ProductName;
        public string ProductPrice => Product.ProductPrice;
        public string ImageName => Product.ImageName;
        public string ProductCategory => Product.ProductCategory;
        public string EstimatedTime => Product.EstimatedTime;
        public BitmapImage ImageSource => new BitmapImage(new Uri(Directory.GetCurrentDirectory() + Product.ImageName, UriKind.Relative));
        public ProductsListingItemViewModel(Product product)
        {
            Product = product;
        }
    }
}
