using System;
using System.Collections.Generic;

namespace No_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Strategy> possibleBeverageBuild = new Dictionary<string, Strategy>();
            possibleBeverageBuild.Add("fast", new FastCleanStrategy());
            possibleBeverageBuild.Add("common", new CommonCleanStrategy());
            possibleBeverageBuild.Add("general", new GeneralCleanStrategy());

            Console.Write("Choose cleaning type(fast/common/general): ");
            string choice = Console.ReadLine();

            Strategy strategy;

            if (possibleBeverageBuild.TryGetValue(choice, out strategy))
            {
                Console.WriteLine($"Cleaning '{choice}' in progress...");

                Housewife hw = new Housewife(strategy);

                hw.CleanFlat();
            }
            else
            {
                Console.WriteLine($"Clean strategy '{choice}' does not exist");
            }
        }
    }
}
