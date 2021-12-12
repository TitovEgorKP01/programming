using System;
using System.Collections.Generic;

namespace No_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, BeverageBuilder> possibleBeverageBuild = new Dictionary<string, BeverageBuilder>();
            possibleBeverageBuild.Add("tea", new TeaBuilder());
            possibleBeverageBuild.Add("coffee", new CoffeeBuilder());
            possibleBeverageBuild.Add("cacao", new CacaoBuilder()); 

            Console.Write("Choose beverage(tea/coffee/cacao): ");
            string choice = Console.ReadLine();

            BeverageBuilder bevBuild;

            if (possibleBeverageBuild.TryGetValue(choice, out bevBuild))
            {
                Machine machine = new Machine();

                machine.Build(bevBuild);
            }
            else
            {
                Console.WriteLine($"Beverage '{choice}' does not exist");
            }
        }
    }
}
