using CoffeeVendingMachine.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace CoffeeVendingMachine.Test.ValueObjects
{
    [ExcludeFromCodeCoverage]
    public class CoffeeBeansTest
    {
        private const decimal costPerUnit = 15.00m;

        [Fact]
        public void GetInstance_Success()
        {
            Ingredient actual = CoffeeBeans.GetInstance(0);

            Assert.NotNull(actual);
            Assert.IsType<CoffeeBeans>(actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void TotalCost_Success(ushort unit)
        {
            Ingredient coffeeBeans = CoffeeBeans.GetInstance(unit);

            decimal expected = CoffeeBeansTest.costPerUnit * unit;
            decimal actual = coffeeBeans.TotalCost();

            Assert.Equal(expected, actual);
        }
    }
}
