﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Domain.Repositories
{
    public interface IHotChocolateServices : IBaseProductServices
    {
        public Task AddDrinkingChocolateToCup();
    }
}
