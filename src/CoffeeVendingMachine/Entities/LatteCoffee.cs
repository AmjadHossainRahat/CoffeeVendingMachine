using CoffeeVendingMachine.ValueObjects;

namespace CoffeeVendingMachine.Entities
{
    public sealed class LatteCoffee : Coffee
    {
        private const ushort requiredUnitOfMilk = 2;
        private const ushort requiredUnitOfCoffeeBeans = 3;

        private Milk milk;
        private CoffeeBeans coffeeBeans;
        private Sugar Sugar;

        private LatteCoffee()
        {
            this.milk = Milk.GetInstance(LatteCoffee.requiredUnitOfMilk);
            this.coffeeBeans = CoffeeBeans.GetInstance(LatteCoffee.requiredUnitOfCoffeeBeans);
            this.Sugar = Sugar.GetInstance(Coffee.defaultUnitOfSugar);
        }

        public override void AddSugar(ushort unit)
        {
            this.Sugar = Sugar.GetInstance(unit);
        }

        public override decimal TotalCost()
        {
            return this.milk.TotalCost() + this.coffeeBeans.TotalCost() + this.Sugar.TotalCost();
        }

        /// <summary>
        /// For centralizing the construction of new object
        /// </summary>
        /// <param name="unit">The number of unit.</param>
        /// <returns><see cref="LatteCoffee"/></returns>
        public static LatteCoffee GetInstance()
        {
            return new LatteCoffee();
        }
    }
}
