using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DataLayer.Models;

namespace VendingMachine.Domain.Repositories
{
    public interface IDataServices
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string userName);
        Task Create(User user);
        Task Update(User user);
        Task Delete(User user);
    }
}
