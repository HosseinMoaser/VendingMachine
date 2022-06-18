using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DataLayer;
using VendingMachine.DataLayer.Models;
using VendingMachine.Domain.Repositories;

namespace VendingMachine.Domain.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IAccountServices _accountService;

        public AuthenticationServices()
        {
        }

        public AuthenticationServices(IAccountServices accountService)
        {
            _accountService = accountService;
        }

        public async Task<User> Login(string userName, string passWord)
        {
            User existsAccount = await _accountService.GetByUserName(userName);

            bool isPasswordMathces = passWord == existsAccount.Passwword;

            if (!isPasswordMathces)
                throw new Exception("Wrong Password");

            return existsAccount;
        }
        
    }
}
