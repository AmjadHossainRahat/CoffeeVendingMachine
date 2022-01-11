using CoffeeVendingMachine.Entities;

namespace CoffeeVendingMachine.Services
{
    public interface ICoffeeFactory
    {
        /// <summary>
        /// Responsible to prepare Coffee.
        /// </summary>
        /// <param name="coffeeTypeEnum">Type of coffee</param>
        /// <param name="sugarUnit">The unit of sugar need to add, optional</param>
        /// <returns><see cref="Coffee"/>The coffee.</returns>
        public Coffee Prepare(CoffeeTypeEnum coffeeTypeEnum, ushort sugarUnit = 0);
    }
}
