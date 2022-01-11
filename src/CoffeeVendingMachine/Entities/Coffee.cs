namespace CoffeeVendingMachine.Entities
{
    public abstract class Coffee
    {
        protected const ushort defaultUnitOfSugar = 0;

        public abstract void AddSugar(ushort unit);

        public abstract decimal TotalCost();
    }
}
