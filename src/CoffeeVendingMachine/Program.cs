using CoffeeVendingMachine.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace CoffeeVendingMachine
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<ICoffeeFactory, CoffeeFactory>()
                .AddSingleton<IVendingMachine, VendingMachine>()
                .BuildServiceProvider();


            IVendingMachine vendingMachine = serviceProvider.GetService<IVendingMachine>();
            vendingMachine.SwitchON();




            Console.ReadLine();
        }
    }
}
