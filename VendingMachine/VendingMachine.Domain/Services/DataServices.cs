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
    public class DataServices : IDataServices
    {
        private VendingMachineDBContextFactory _contextFactory;

        // Constructor
        public DataServices(VendingMachineDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Get All Users
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using(VendingMachineDBContext db = _contextFactory.CreateDBContext())
            {
                return await db.Users.ToListAsync();
            }
        }

        // Get User By ID
        public async Task<User> GetUserById(int id)
        {
            using (VendingMachineDBContext db = _contextFactory.CreateDBContext())
                return await db.Users.FindAsync(id);
        }

        // Get User By UserName
        public async Task<User> GetUserByName(string userName)
        {
            using (VendingMachineDBContext db = _contextFactory.CreateDBContext())
                return await db.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            
        }

        // Delete
        public async Task Delete(User user)
        {
            using (VendingMachineDBContext db = _contextFactory.CreateDBContext())
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
        }

        // Update
        public async Task Update(User user)
        {
            using (VendingMachineDBContext db = _contextFactory.CreateDBContext())
            {
                db.Users.Update(user);
                await db.SaveChangesAsync();
            }
        }

        // Create User
        public async Task Create(User user)
        {
            using (VendingMachineDBContext db = _contextFactory.CreateDBContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
