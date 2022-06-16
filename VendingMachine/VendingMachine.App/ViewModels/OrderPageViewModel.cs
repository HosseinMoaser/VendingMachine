using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendingMachine.App.Models;

namespace VendingMachine.App.ViewModels
{
    public class OrderPageViewModel : BaseViewModel
    {
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set 
            {
                _productName = value; 
            }
        }

        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set 
            { 
                _imageName = value;
            }
        }

        private bool _isCanceled;
        public bool IsCanceled
        {
            get { return _isCanceled; }
            set
            {
                _isCanceled = value;
                OnPropertyChanged(nameof(IsCanceled));
                OnPropertyChanged(nameof(CanBackHome));
            }
        }

        private bool _isCompleted;

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
                OnPropertyChanged(nameof(CanBackHome));
            }
        }

        public bool CanBackHome => IsCompleted || IsCanceled;
        public ICommand CancelOrderCommand { get; }
        public ICommand BackToHomeCommand { get; }

        public OrderPageViewModel(ICommand cancelOrderCommand, ICommand backToHomeCommand)
        {
            CancelOrderCommand = cancelOrderCommand;
            BackToHomeCommand = backToHomeCommand;
        }
    }
}
