using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DataLayer.Models;

namespace VendingMachine.Domain.Repositories
{
    public interface IAccountServices
    {
        Task<User> GetByUserName(string userName);
        Task<User> CreateAccount(User account);
    }
}
