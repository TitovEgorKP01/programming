using System;

namespace No_1
{
    class FastCleanStrategy : Strategy
    {
        public override void Clean()
        {
            Console.WriteLine("Scattered things are stacked; The floor was swept");
        }
    }
}
