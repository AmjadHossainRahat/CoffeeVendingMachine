namespace CoffeeVendingMachine.ValueObjects
{
    public sealed class CoffeeBeans : Ingredient
    {
        private CoffeeBeans() { }

        private CoffeeBeans(ushort unit)
        {
            this.costPerUnit = 15.00m;
            this.totalUnit = unit;
        }

        /// <summary>
        /// For centralizing the construction of new object
        /// </summary>
        /// <param name="unit">The number of unit.</param>
        /// <returns><see cref="CoffeeBeans"/></returns>
        public static CoffeeBeans GetInstance(ushort unit)
        {
            return new CoffeeBeans(unit);
        }
    }
}
