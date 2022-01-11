using CoffeeVendingMachine.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace CoffeeVendingMachine.Test.ValueObjects
{
    [ExcludeFromCodeCoverage]
    public class SugarTest
    {
        private const decimal costPerUnit = 5.00m;

        [Fact]
        public void GetInstance_Success()
        {
            Ingredient actual = Sugar.GetInstance(0);

            Assert.NotNull(actual);
            Assert.IsType<Sugar>(actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void TotalCost_Success(ushort unit)
        {
            Ingredient sugar = Sugar.GetInstance(unit);

            decimal expected = SugarTest.costPerUnit * unit;
            decimal actual = sugar.TotalCost();

            Assert.Equal(expected, actual);
        }
    }
}
