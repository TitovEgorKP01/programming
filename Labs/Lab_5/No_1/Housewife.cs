namespace No_1
{
    class Housewife
    {
        private Strategy _strategy;

        public Housewife(Strategy strategy)
        {
            _strategy = strategy;
        }

        public void CleanFlat()
        {
            _strategy.Clean();
        }
    }
}
