namespace No_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Manufacturer man1 = new Manufacturer(100);
            Manufacturer man2 = new Manufacturer(50);
            Manufacturer man3 = new Manufacturer(70);

            Supplier sup = new MainSupplier();
            sup.RegisterManufacturer(man1);
            sup.RegisterManufacturer(man2);
            sup.RegisterManufacturer(man3);

            Market market = new Market(sup);
            market.BuyProducts(100);
            market.BuyProducts(100);
            market.BuyProducts(100);
        }
    }
}
