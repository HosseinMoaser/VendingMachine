using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Models
{
    public class Product
    {
        public Product(string productName, string productPrice, string productCategory, string estimatedTime, string imageName)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductCategory = productCategory;
            EstimatedTime = estimatedTime;
            ImageName = imageName;
        }

        public string ProductName { get; }
        public string ProductPrice { get; }
        public string ProductCategory { get; }
        public string EstimatedTime { get; }
        public string ImageName { get; }
    }
}
