using CoffeeVendingMachine.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Services
{
    [ExcludeFromCodeCoverage]   // It requires integration testing
    public sealed class VendingMachine : IVendingMachine
    {
        private bool isSwitchON;
        private ICoffeeFactory coffeeFactory;
        public VendingMachine(ICoffeeFactory coffeeFactory)
        {
            this.isSwitchON = false;
            this.coffeeFactory = coffeeFactory;
        }

        public void SwitchON()
        {
            this.isSwitchON = true;

            while (this.isSwitchON)
            {
                Console.WriteLine("Press any key to start");
                Console.ReadKey();

                this.fencyStarting();

                try
                {
                    Coffee coffee = this.PlaceOrder();

                    Console.WriteLine($"Enjoy your drink!{Environment.NewLine}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public ushort AddSugar()
        {
            Console.Write("Enter unit of sugar: ");
            string unitStr = Console.ReadLine();

            ushort givenUnit = 0;
            if (ushort.TryParse(unitStr, out givenUnit))
            {
                return givenUnit;
            }

            throw new Exception("Invalid unit was given as input. Canceling the order...");
        }

        public void PayTheBill(decimal due)
        {
            Console.Write($"Please pay the amount ${due}: ");
            string paidAmountStr = Console.ReadLine();

            decimal paidAmount = decimal.Zero;
            if (!decimal.TryParse(paidAmountStr, out paidAmount))
            {
                throw new Exception("Invalid amount was given. Canceling the order...");
            }

            while(paidAmount < due)
            {
                Console.Write($"You need to pay {due-paidAmount} more or press Enter button to cancel the order: ");
                string givenInput = Console.ReadLine();
                if (string.IsNullOrEmpty(givenInput))
                {
                    throw new Exception($"Please collect the amount {paidAmount} you paid.{Environment.NewLine}Canceling the order...");
                }

                decimal newPaidAmount = decimal.Zero;
                if (!decimal.TryParse(givenInput, out newPaidAmount))
                {
                    throw new Exception($"Invalid amount was given.{Environment.NewLine}Collect the money.{Environment.NewLine}Canceling the order...");
                }

                paidAmount += newPaidAmount;
            }

            if (paidAmount > due)
            {
                Console.WriteLine($"Collect the change ${paidAmount-due}...");
            }

            return;
        }

        private Coffee PlaceOrder()
        {
            Console.WriteLine("1 (for Latte Coffee)");
            Console.WriteLine("2 (for Black Coffee)");
            Console.WriteLine("0 (to cancel)");
            Console.Write("Please enter the number: ");

            string givenInput = Console.ReadLine();
            int number = 0;

            if (!int.TryParse(givenInput, out number) || number < 0 || number > 2)
            {
                throw new Exception("Invalid input. Canceling the order...");
            }

            if (number == 0)
            {
                throw new Exception("Canceling the order...\n");
            }

            ushort sugarUnit = this.AddSugar();

            Coffee coffee = this.coffeeFactory.Prepare((CoffeeTypeEnum)number, sugarUnit);

            this.PayTheBill(coffee.TotalCost());

            return coffee;
        }

        private void fencyStarting()
        {
            int loopCount = 5;
            Console.Write($"{Environment.NewLine}Starting");
            while (loopCount-- > 0)
            {
                Task.Delay(TimeSpan.FromSeconds(2)).GetAwaiter().GetResult();
                Console.Write(".");
            }
            Console.WriteLine(Environment.NewLine);
        }

        public void SwitchOFF()
        {
            this.isSwitchON = false;
        }
    }
}
