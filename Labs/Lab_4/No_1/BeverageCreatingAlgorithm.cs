using System;

namespace No_1
{
    class BeverageCreatingAlgorithm
    {
        public void CreateBeverage(IBeverage bev)
        {
            bev.AddFirst();

            bev.AddSecond();

            Console.Write($"Your order: '{bev.GetDescription()}'");
        }
    }
}
