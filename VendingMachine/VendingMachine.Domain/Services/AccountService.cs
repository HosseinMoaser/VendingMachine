using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class AccountServices : IAccountServices
    {
        private readonly VendingMachineDBContextFactory _contextFactory;

        public AccountServices(VendingMachineDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<User> CreateAccount(User account)
        {
            using (VendingMachineDBContext db = _contextFactory.CreateDBContext())
            {
                EntityEntry<User> createdEntity = await db.Set<User>().AddAsync(account);
                await db.SaveChangesAsync();
                return createdEntity.Entity;
            }
        }

        public async Task<User> GetByUserName(string userName)
        {
            using (VendingMachineDBContext db = _contextFactory.CreateDBContext())
            {
                User user = await db.Users.FirstOrDefaultAsync(a => a.UserName == userName);
                return user;
            }
        }
    }
}
