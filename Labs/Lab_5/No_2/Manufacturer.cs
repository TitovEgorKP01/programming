namespace No_2
{
    class Manufacturer
    {
        protected int countOfProducts;

        public Manufacturer(int countOfProducts)
        {
            this.countOfProducts = countOfProducts;
        }

        public int ProductsCount
        {
            get
            {
                return countOfProducts;
            }
            set
            {
                if (countOfProducts >= 0)
                {
                    this.countOfProducts = value;
                }
            }
        }

        public int SellProducts(int requestedCount)
        {
            int sellCount = 0;

            if (countOfProducts < requestedCount)
            {
                sellCount = countOfProducts;
            
                countOfProducts = 0;
            }
            else
            {
                sellCount = requestedCount;

                countOfProducts -= requestedCount;
            }

            return sellCount;
        }
    }
}
