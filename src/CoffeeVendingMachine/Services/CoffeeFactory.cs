using CoffeeVendingMachine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeVendingMachine.Services
{
    public sealed class CoffeeFactory : ICoffeeFactory
    {
        /// <summary>
        /// Factory method for Coffee.
        /// </summary>
        /// <param name="coffeeTypeEnum"></param>
        /// <param name="sugarUnit"></param>
        /// <returns></returns>
        public Coffee Prepare(CoffeeTypeEnum coffeeTypeEnum, ushort sugarUnit)
        {
            Coffee coffee = null;
            switch (coffeeTypeEnum)
            {
                case CoffeeTypeEnum.Latte:
                    coffee = LatteCoffee.GetInstance();
                    coffee.AddSugar(sugarUnit);
                    break;

                case CoffeeTypeEnum.Black:
                    coffee = BlackCoffee.GetInstance();
                    coffee.AddSugar(sugarUnit);
                    break;
            }

            return coffee;
        }
    }
}
