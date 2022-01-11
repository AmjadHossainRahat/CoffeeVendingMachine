namespace CoffeeVendingMachine.ValueObjects
{
    public sealed class Milk : Ingredient
    {
        private Milk() { }

        private Milk(ushort unit)
        {
            this.costPerUnit = 10.00m;
            this.totalUnit = unit;
        }

        /// <summary>
        /// For centralizing the construction of new object
        /// </summary>
        /// <param name="unit">The number of unit.</param>
        /// <returns><see cref="Milk"/></returns>
        public static Milk GetInstance(ushort unit)
        {
            return new Milk(unit);
        }
    }
}
