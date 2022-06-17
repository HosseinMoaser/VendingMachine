using VendingMachine.DataLayer.Models;

namespace VendingMachine.Domain.Repositories
{
    public interface IAuthenticationServices
    {
        User Login(string userName, string passWord);
    }
}
