namespace No_1
{
    abstract class BeverageBuilder
    {
        protected string[] firstParameters;
        protected string[] secondParameters;
        protected Beverage beverage;

        public Beverage Beverage
        {
            get
            {
                return beverage;
            }
        }

        public abstract void AddFirst();
        public abstract void AddSecond();
    }
}
