using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.App.ViewModels;
using VendingMachine.DataLayer.Models;
using VendingMachine.Domain.Repositories;

namespace VendingMachine.App.State
{
    public class Authenticator : BaseViewModel,IAuthenticator
    {
        private IAuthenticationServices _authenticationService;
        public Authenticator(IAuthenticationServices authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private User _user;
        public User User 
        {
            get { return _user; }
            private set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public bool Login(string username, string password)
        {
            bool success = true;
            try
            {
                User =  _authenticationService.Login(username, password);
                if (User == null)
                    success = false;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }
    }
}
