namespace CoffeeVendingMachine.ValueObjects
{
    public abstract class Ingredient
    {
        protected decimal costPerUnit = decimal.Zero;
        protected decimal totalUnit = decimal.Zero;

        /// <summary>
        /// Calculates the total cost of the ingredient.
        /// </summary>
        /// <returns><see cref="decimal"/>Total cost</returns>
        public virtual decimal TotalCost()
        {
            return this.costPerUnit * this.totalUnit;
        }
    }
}
