using System;

namespace No_1
{
    class CoffeeBuilder : BeverageBuilder
    {
        public CoffeeBuilder()
        {
            firstParameters = new string[]{"milk", "vanilla"};

            secondParameters = new string[]{"1x sugar", "2x sugar", "3x sugar"};

            beverage = new Beverage();
            beverage.Add("coffee");
        }

        public override void AddFirst()
        {
            Console.Write("Enter first additional parameter(milk/vanilla): ");
            string choosenParameter = Console.ReadLine();

            foreach(string par in firstParameters)
            {
                if (choosenParameter == par)
                {
                    beverage.Add(choosenParameter);
                }
            }
        }

        public override void AddSecond()
        {
            Console.Write("Enter second additional parameter(1x/2x/3x sugar): ");
            string choosenParameter = Console.ReadLine();

            foreach(string par in secondParameters)
            {
                if (choosenParameter == par)
                {
                    beverage.Add(choosenParameter);
                }
            }
        }
    }
}
