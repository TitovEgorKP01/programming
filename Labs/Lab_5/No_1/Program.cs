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
                Housewife machine = new Housewife(strategy);

                machine.CleanFlat();
            }
            else
            {
                Console.WriteLine($"Clean strategy '{choice}' does not exist");
            }
        }
    }

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

    abstract class Strategy
    {
        public abstract void Clean();
    }

    class FastCleanStrategy : Strategy
    {
        public override void Clean()
        {
            Console.WriteLine("Fast cleaning in process...");
            Console.WriteLine("Scattered things are stacked; The floor was swept");
        }
    }

    class CommonCleanStrategy : Strategy
    {
        public override void Clean()
        {
            Console.WriteLine("Common cleaning in process...");
            Console.WriteLine("The dust has been wiped away; Vacuum cleaner used");
        }
    }

    class GeneralCleanStrategy : Strategy
    {
        public override void Clean()
        {
            Console.WriteLine("General cleaning in process...");
            Console.WriteLine("Wet cleaning of the floor carried out; The windows were washed");
        }
    }
}
