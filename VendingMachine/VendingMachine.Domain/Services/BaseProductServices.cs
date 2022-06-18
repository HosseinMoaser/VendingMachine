using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Repositories;

namespace VendingMachine.Domain.Services
{
    public class BaseProductServices : IBaseProductServices
    {
        public async Task AddWater()
        {
            MainMethod();
        }

        public async Task BoilWater()
        {
            MainMethod();
        }

        public async void MainMethod()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });
        }

        public virtual  List<Action> CreateService()
        {
            List<Action> actions = new List<Action>();
            actions.Add(MainMethod);
            actions.Add(MainMethod);
            actions.Add(MainMethod);
            actions.Add(MainMethod);
            actions.Add(MainMethod);
            return actions;
        }         
    }
}
