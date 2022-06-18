using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Repositories
{
    public interface IIcedCoffeeServices : IBaseProductServices
    {
        public Task CrushIce();
        public Task AddIceToBlender();
        public Task AddCoffeeSyrupToBlender();
        public Task BlendIngredients();
        public Task AddIngredients();

    }
}
