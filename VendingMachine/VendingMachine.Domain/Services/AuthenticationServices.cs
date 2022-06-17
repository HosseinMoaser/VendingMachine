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
        private readonly VendingMachineDBContextFactory _contextFactory;

        public AuthenticationServices(VendingMachineDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public User Login(string userName, string passWord)
        {
            using (VendingMachineDBContext db = _contextFactory.CreateDBContext())
            {
                return db.Users.FirstOrDefault(u=> u.UserName == userName && u.Passwword==passWord);
            }
        }
    }
}
