using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.DataLayer.Models;

namespace VendingMachine.DataLayer
{
    public class VendingMachineDBContext : DbContext
    {
        public VendingMachineDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public Task<User> FirstOrDefaultAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
