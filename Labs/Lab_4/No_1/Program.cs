using System;
using System.Collections.Generic;

namespace No_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBeverage> possibleBeverages = new Dictionary<string, IBeverage>();
            possibleBeverages.Add("tea", new Tea());
            possibleBeverages.Add("coffee", new Coffee());
            possibleBeverages.Add("cacao", new Cacao());

            Console.Write("Choose beverage(tea/coffee/cacao): ");
            string choice = Console.ReadLine();

            IBeverage bev;

            if (possibleBeverages.TryGetValue(choice, out bev))
            {
                BeverageCreatingAlgorithm alg = new BeverageCreatingAlgorithm();

                alg.CreateBeverage(bev);
            }
            else
            {
                Console.WriteLine($"Beverage '{choice}' does not exist");
            }
        }
    }
}
