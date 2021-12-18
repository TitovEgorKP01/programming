namespace No_2
{
    abstract class Supplier
    {
        public abstract void RegisterManufacturer(Manufacturer manufacturer);
        public abstract int RequestProducts(int requestedCount);
    }
}
