namespace No_1
{
    class Machine
    {
        public void Build(BeverageBuilder bev)
        {
            bev.AddFirst();
            bev.AddSecond();

            bev.Beverage.Show();
        }
    }
}
