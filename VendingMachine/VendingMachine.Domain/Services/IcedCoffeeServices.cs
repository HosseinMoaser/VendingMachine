using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Repositories;

namespace VendingMachine.Domain.Services
{
    public class IcedCoffeeServices : BaseProductServices, IIcedCoffeeServices
    {
        public async Task AddCoffeeSyrupToBlender()
        {
            MainMethod();
        }

        public async Task AddIceToBlender()
        {
            MainMethod();
        }

        public async Task AddIngredients()
        {
            MainMethod();
        }

        public async Task BlendIngredients()
        {
            MainMethod();

        }

        public async Task CrushIce()
        {
            MainMethod();

        }
    }
}
