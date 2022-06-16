using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendingMachine.App.Stores;

namespace VendingMachine.App.Commands
{
    public class BackFromModalCommand : ICommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public BackFromModalCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _modalNavigationStore.Close();
        }
    }
}
