using VendingMachine.DataLayer.Models;

namespace VendingMachine.Domain.Repositories
{
    public interface IAuthenticationServices
    {
        Task<User> Login(string userName, string passWord);
    }
}
