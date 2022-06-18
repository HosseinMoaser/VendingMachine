using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Repositories
{
    public interface IBaseProductServices
    {
        public Task BoilWater();
        public Task AddWater();
    }
}
