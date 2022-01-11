namespace CoffeeVendingMachine.ValueObjects
{
    public sealed class Sugar : Ingredient
    {
        private Sugar() { }

        private Sugar(ushort unit)
        {
            this.costPerUnit = 5.00m;
            this.totalUnit = unit;
        }

        /// <summary>
        /// For centralizing the construction of new object
        /// </summary>
        /// <param name="unit">The number of unit.</param>
        /// <returns><see cref="Sugar"/></returns>
        public static Sugar GetInstance(ushort unit)
        {
            return new Sugar(unit);
        }
    }
}
