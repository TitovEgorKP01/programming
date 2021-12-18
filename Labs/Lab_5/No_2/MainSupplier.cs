using System.Collections.Generic;

namespace No_2
{
    class MainSupplier : Supplier
    {
        private List<Manufacturer> _mfacturers;

        public MainSupplier()
        {
            this._mfacturers = new List<Manufacturer>();
        }

        public override void RegisterManufacturer(Manufacturer manufacturer)
        {
            if (!_mfacturers.Contains(manufacturer))
            {
                _mfacturers.Add(manufacturer);
            }
        }

        public override int RequestProducts(int requestedCount)
        {
            List<Manufacturer> currentMarketManufacturers = new List<Manufacturer>();
            int guarantedCount = 0;

            foreach (Manufacturer manf in _mfacturers)
            {
                guarantedCount += manf.ProductsCount;
                currentMarketManufacturers.Add(manf);

                if (guarantedCount >= requestedCount)
                {           
                    guarantedCount = requestedCount;

                    break;
                }
            }

            int receivedCount = BuyManfProducts(guarantedCount, currentMarketManufacturers);

            return receivedCount;
        }

        private int BuyManfProducts(int count, List<Manufacturer> list)
        {
            int receivedCount = 0;

            foreach (Manufacturer manf in list)
            {   
                int soldProds = manf.SellProducts(count);

                receivedCount += soldProds;
                
                count -= soldProds;
            }

            return receivedCount;
        }
    }
}
