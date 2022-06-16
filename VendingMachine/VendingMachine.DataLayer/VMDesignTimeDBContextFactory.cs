using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.DataLayer
{
    public class VMDesignTimeDBContextFactory : IDesignTimeDbContextFactory<VendingMachineDBContext>
    {
        public VendingMachineDBContext CreateDbContext(string[] args=null)
        {
            return new VendingMachineDBContext(new DbContextOptionsBuilder().UseSqlite("Data Source = VendingMachineDB.db").Options);
        }
    }
}
