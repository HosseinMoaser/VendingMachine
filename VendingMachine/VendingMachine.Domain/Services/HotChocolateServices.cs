using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Repositories;

namespace VendingMachine.Domain.Services
{
    public class HotChocolateServices : BaseProductServices, IHotChocolateServices
    {
        public async Task AddDrinkingChocolateToCup()
        {
            MainMethod();
        }

        public override List<Action> CreateService()
        {
            List<Action> actions = new List<Action>();
            actions.Add(MainMethod);
            actions.Add(MainMethod);
            actions.Add(MainMethod);
            return actions;
        }
    }
}
