using System;

namespace No_2
{
    class Market
    {
        private Supplier _supplier;
        private int _productsCount = 0;

        public Market(Supplier sup)
        {
            _supplier = sup;
        }

        public void BuyProducts(int count)
        {
            if (_supplier != null)
            {
                Console.WriteLine($"Requesting '{count}' products in supplier");

                int receivedCount = _supplier.RequestProducts(count);

                _productsCount += receivedCount;

                Console.WriteLine($"Supplier has provided '{receivedCount}' products");
            }
        }
    }
}
