using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Models;

namespace VendingMachine.App.Stores
{
    public class SelectedProductStore
    {
        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            { 
                _selectedProduct = value;
                SelectedProductChanged?.Invoke();
            }
        }

        public event Action SelectedProductChanged;
    }
}
