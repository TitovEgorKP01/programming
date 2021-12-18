using System;

namespace No_1
{
    class GeneralCleanStrategy : Strategy
    {
        public override void Clean()
        {
            Console.WriteLine("Wet cleaning of the floor carried out; The windows were washed");
        }
    }
}
