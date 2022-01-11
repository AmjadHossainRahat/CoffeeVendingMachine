using CoffeeVendingMachine.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace CoffeeVendingMachine.Test.ValueObjects
{
    [ExcludeFromCodeCoverage]
    public class MilkTest
    {
        private const decimal costPerUnit = 10.00m;

        [Fact]
        public void GetInstance_Success()
        {
            Ingredient actual = Milk.GetInstance(0);

            Assert.NotNull(actual);
            Assert.IsType<Milk>(actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void TotalCost_Success(ushort unit)
        {
            Ingredient milk = Milk.GetInstance(unit);

            decimal expected = MilkTest.costPerUnit * unit;
            decimal actual = milk.TotalCost();

            Assert.Equal(expected, actual);
        }
    }
}
