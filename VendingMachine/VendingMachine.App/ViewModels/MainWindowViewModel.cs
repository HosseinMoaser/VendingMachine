using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.App.State;
using VendingMachine.App.Stores;

namespace VendingMachine.App.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public HomeViewModel HomeViewModel { get;  }
        private readonly ModalNavigationStore _modalNavigationStore;
        public IAuthenticator Authenticator { get; set; }
        public BaseViewModel CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;

        // MainViewModel Constructor
        public MainWindowViewModel(HomeViewModel homeViewModel, ModalNavigationStore modalNavigationStore)
        {
            HomeViewModel = homeViewModel;
            _modalNavigationStore = modalNavigationStore;
            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;
            base.Dispose();
        }
        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
