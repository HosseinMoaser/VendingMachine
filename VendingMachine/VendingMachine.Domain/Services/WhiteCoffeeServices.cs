using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Repositories;

namespace VendingMachine.Domain.Services
{
    public class WhiteCoffeeServices : BaseProductServices, IWhiteCoffeeServices
    {
        public async Task AddCoffeeGranulesToCup()
        {
            MainMethod();
        }

        public async Task AddMilk()
        {
            MainMethod();

        }

        public async Task AddSugar()
        {
            MainMethod();
        }

    }
}
