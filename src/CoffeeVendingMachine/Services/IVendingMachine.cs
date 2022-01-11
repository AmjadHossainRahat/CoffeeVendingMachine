namespace CoffeeVendingMachine.Services
{
    public interface IVendingMachine
    {
        /// <summary>
        /// Responsible for switching ON the vending machine.
        /// </summary>
        public void SwitchON();

        /// <summary>
        /// Responsible for switching OFF the vending machine.
        /// </summary>
        public void SwitchOFF();
    }
}
