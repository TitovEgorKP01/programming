using System;
using System.Collections.Generic;

namespace No_1
{
    class Cacao : IBeverage
    {
        string[] firstParameters = {"honey", "vanilla"};
        string[] secondParameters = {"1x sugar", "2x sugar", "3x sugar"};

        List<string> components = new List<string>();

        public void AddFirst()
        {
            Console.Write("Enter first additional parameter(honey/vanilla): ");
            string choosenParameter = Console.ReadLine();

            foreach(string par in firstParameters)
            {
                if (choosenParameter == par)
                {
                    components.Add(choosenParameter);
                }
            }
        }

        public void AddSecond()
        {
            Console.Write("Enter second additional parameter(1x/2x/3x sugar): ");
            string choosenParameter = Console.ReadLine();

            foreach(string par in secondParameters)
            {
                if (choosenParameter == par)
                {
                    components.Add(choosenParameter);
                }
            }
        }

        public string GetDescription()
        {
            string descr = "Cacao";

            if (components.Count != 0)
            {
                descr += $" with parameters: {String.Join(',', components.ToArray())}";
            }

            return descr;
        }
    }
}
