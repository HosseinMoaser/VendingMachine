using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VendingMachine.DataLayer.Models;
using VendingMachine.Domain.Services;

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

        public BitmapImage ImageSource { get; set; }

        private bool _isCanceled;
        public bool IsCanceled
        {
            get { return _isCanceled; }
            set
            {
                _isCanceled = value;
                IsCancelButtonVisible = !value;
                OnPropertyChanged(nameof(IsCanceled));
                OnPropertyChanged(nameof(CanBackHome));
            }
        }

        private bool _isCancelButtonVisible;
        public bool IsCancelButtonVisible
        {
            get
            {
                return _isCancelButtonVisible;
            }
            set
            {
                _isCancelButtonVisible = value;
                OnPropertyChanged(nameof(IsCancelButtonVisible));
            }
        }

        private bool _isCompleted;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                IsCancelButtonVisible = false;
                OnPropertyChanged(nameof(CanBackHome));
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        public bool CanBackHome => IsCompleted || IsCanceled;

        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public ObservableCollection<string> Steps
        {
            get;
            set;
        }

        public ICommand CancelOrderCommand { get; }
        public ICommand BackToHomeCommand { get; }
        public ICommand BaseProductPreparingCommand { get; }

        public OrderPageViewModel(ICommand cancelOrderCommand, ICommand backToHomeCommand, BaseProductServices productServices)
        {
            CancelOrderCommand = cancelOrderCommand;
            BackToHomeCommand = backToHomeCommand;
            ApplyService(productServices);
        }

        private async void ApplyService(BaseProductServices productServices)
        {
            List<Action> actions = productServices.CreateService();
            Progress = 100 / actions.Count;
            int step = 100 / actions.Count;
            foreach (Action service in actions)
            {
                // This is simulation for each service..
                // services could be replace with various
                // implementations in domain layer
                    await Task.Run(() =>
                    {
                        if (!_isCanceled)
                        {
                            Thread.Sleep(1500);
                            Progress += step;
                        }
                    });
            }

            if (Progress >= 100)
                IsCompleted = true;
        }
    }
}
