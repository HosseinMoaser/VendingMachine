using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.DataLayer
{
    public class VendingMachineDBContextFactory
    {
        private readonly DbContextOptions _options;

        public VendingMachineDBContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public VendingMachineDBContext CreateDBContext()
        {
            return new VendingMachineDBContext(_options);
        }
    }
}
