using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Services;

namespace VendingMachine.App.ProductsTools
{
    public static class ProductTools
    {
        public static ObservableCollection<string> GetSteps(string productName)
        {
            switch (productName.ToLower())
            {
                case "hot chocolate":
                    return new ObservableCollection<string>() { "Boil Water", "Add drinking chocolate to cup", "Add water" };
                case "lemon tea":
                    return new ObservableCollection<string>() { "Boil Water", "Add water", "Steep tea bag", "Add lemon" };
                case "white coffee":
                    return new ObservableCollection<string>() { "Boil Water", "Add sugar", "Add coffee granules ", "Add water", "Add milk" };
                case "iced coffee":
                    return new ObservableCollection<string>() { "Crush Ice", "Add ice to blender", "Add coffee syrup to blender", "Blend ingredients", "Add ingredients" };
                default:
                    return new ObservableCollection<string>() { "Boil Water", "•	Add drinking chocolate to cup", "•	Add water" };
            }
        }

        public static BaseProductServices GetService(string productName)
        {
            switch (productName.ToLower())
            {
                case "hot chocolate":
                    return new HotChocolateServices();
                case "lemon tea":
                    return new LemonTeaServices();
                case "white coffee":
                    return new WhiteCoffeeServices();
                case "iced coffee":
                    return new IcedCoffeeServices();
                default:
                    return new BaseProductServices();
            }
        }
        
    }
}
