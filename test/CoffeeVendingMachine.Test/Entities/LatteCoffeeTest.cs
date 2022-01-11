using CoffeeVendingMachine.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeVendingMachine.Test.Entities
{
    [ExcludeFromCodeCoverage]
    public class LatteCoffeeTest
    {
        [Fact]
        public void GetInstance_Success()
        {
            Coffee actual = LatteCoffee.GetInstance();

            Assert.NotNull(actual);
            Assert.IsType<LatteCoffee>(actual);
        }

        [Fact]
        public void TotalCost_WithoutAddingSugar_Success()
        {
            LatteCoffee expected = LatteCoffee.GetInstance();
            Coffee actual = LatteCoffee.GetInstance();

            Assert.Equal(expected.TotalCost(), actual.TotalCost());

            expected.AddSugar(0);
            Assert.Equal(expected.TotalCost(), actual.TotalCost());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(109)]
        public void TotalCost_WithoutAddingSugar_Fails(ushort sugarUnit)
        {
            LatteCoffee expected = LatteCoffee.GetInstance();
            expected.AddSugar(sugarUnit);

            Coffee actual = LatteCoffee.GetInstance();

            Assert.NotEqual(expected.TotalCost(), actual.TotalCost());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(109)]
        public void TotalCost_WithAddingSugar_Success(ushort sugarUnit)
        {
            LatteCoffee expected = LatteCoffee.GetInstance();
            expected.AddSugar(sugarUnit);

            Coffee actual = LatteCoffee.GetInstance();
            actual.AddSugar(sugarUnit);

            Assert.Equal(expected.TotalCost(), actual.TotalCost());
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(5, 6)]
        [InlineData(100,10)]
        [InlineData(3, 109)]
        public void TotalCost_WithAddingSugar_Fails(ushort unit1, ushort unit2)
        {
            LatteCoffee expected = LatteCoffee.GetInstance();
            expected.AddSugar(unit1);

            Coffee actual = LatteCoffee.GetInstance();
            actual.AddSugar(unit2);

            Assert.NotEqual(expected.TotalCost(), actual.TotalCost());
        }
    }
}
