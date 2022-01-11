using CoffeeVendingMachine.Entities;
using CoffeeVendingMachine.Services;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace CoffeeVendingMachine.Test.Services
{
    [ExcludeFromCodeCoverage]
    public class CoffeeFactoryTest
    {
        private ICoffeeFactory coffeeFactory;
        public CoffeeFactoryTest()
        {
            this.coffeeFactory = new CoffeeFactory();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(9)]
        public void Prepare_Returns_Null(ushort sugarUnit)
        {
            Coffee coffee = this.coffeeFactory.Prepare(CoffeeTypeEnum.None, sugarUnit);

            Assert.Null(coffee);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(9)]
        public void Prepare_Returns_LatteCoffee(ushort sugarUnit)
        {
            Coffee coffee = this.coffeeFactory.Prepare(CoffeeTypeEnum.Latte, sugarUnit);

            Assert.NotNull(coffee);
            Assert.IsType<LatteCoffee>(coffee);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(9)]
        public void Prepare_Returns_BlackCoffee(ushort sugarUnit)
        {
            Coffee coffee = this.coffeeFactory.Prepare(CoffeeTypeEnum.Black, sugarUnit);

            Assert.NotNull(coffee);
            Assert.IsType<BlackCoffee>(coffee);
        }
    }
}
