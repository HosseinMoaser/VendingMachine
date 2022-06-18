using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DataLayer.Models;

namespace VendingMachine.App.State
{
    public interface IAuthenticator
    {
        User User { get; }
        //bool Login(string username, string password);
        Task<bool> Login(string username, string password);
    }
}
