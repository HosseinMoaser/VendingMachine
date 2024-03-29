﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DataLayer.Models;
using VendingMachine.App.Stores;
using VendingMachine.Domain.Models;
using System.Windows.Media.Imaging;
using System.IO;

namespace VendingMachine.App.ViewModels
{
    public class ProductDetailViewModel : BaseViewModel
    {
        private readonly SelectedProductStore _selectedProductStore;
        private Product SelectedProduct => _selectedProductStore.SelectedProduct;

        public bool HasSelectedProduct => SelectedProduct != null;
        public string ProductName => SelectedProduct?.ProductName??string.Empty;
        public string Price => SelectedProduct?.ProductPrice ?? string.Empty;
        public string EstimatedTime => SelectedProduct?.EstimatedTime ?? string.Empty;
        public string Category => SelectedProduct?.ProductCategory ?? string.Empty;
        public string ImageName => SelectedProduct?.ImageName ?? string.Empty;
        public BitmapImage ImageSource { 
            get
            {
                if (SelectedProduct != null)
                    return new BitmapImage(new Uri(Directory.GetCurrentDirectory() + SelectedProduct.ImageName, UriKind.Relative));
                else
                    return null;
            } }

        public ProductDetailViewModel(SelectedProductStore selectedProductStore)
        {
            _selectedProductStore = selectedProductStore;
            _selectedProductStore.SelectedProductChanged += _selectedProductStore_SelectedProductChanged;
        }

        protected override void Dispose()
        {
            _selectedProductStore.SelectedProductChanged -= _selectedProductStore_SelectedProductChanged;
            base.Dispose();
        }

        private void _selectedProductStore_SelectedProductChanged()
        {
            OnPropertyChanged(nameof(HasSelectedProduct));
            OnPropertyChanged(nameof(ProductName));
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(EstimatedTime));
            OnPropertyChanged(nameof(Category));
            OnPropertyChanged(nameof(ImageName));
            OnPropertyChanged(nameof(ImageSource));
        }
    }
}
