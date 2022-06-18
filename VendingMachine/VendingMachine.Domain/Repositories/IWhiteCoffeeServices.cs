using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Repositories
{
    public interface IWhiteCoffeeServices : IBaseProductServices
    {
        public Task AddSugar();
        public Task AddCoffeeGranulesToCup();
        public Task AddMilk();
    }
}
