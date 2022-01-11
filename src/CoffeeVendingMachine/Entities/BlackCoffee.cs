using CoffeeVendingMachine.ValueObjects;

namespace CoffeeVendingMachine.Entities
{
    public sealed class BlackCoffee : Coffee
    {
        private const ushort requiredUnitOfCoffeeBeans = 4;

        private CoffeeBeans coffeeBeans;
        private Sugar Sugar;

        private BlackCoffee()
        {
            this.coffeeBeans = CoffeeBeans.GetInstance(BlackCoffee.requiredUnitOfCoffeeBeans);
            this.Sugar = Sugar.GetInstance(Coffee.defaultUnitOfSugar);
        }

        public override void AddSugar(ushort unit)
        {
            this.Sugar = Sugar.GetInstance(unit);
        }

        public override decimal TotalCost()
        {
            return this.coffeeBeans.TotalCost() + this.Sugar.TotalCost();
        }

        /// <summary>
        /// For centralizing the construction of new object
        /// </summary>
        /// <param name="unit">The number of unit.</param>
        /// <returns><see cref="BlackCoffee"/></returns>
        public static BlackCoffee GetInstance()
        {
            return new BlackCoffee();
        }
    }
}
