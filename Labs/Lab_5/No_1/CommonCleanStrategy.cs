using System;

namespace No_1
{
    class CommonCleanStrategy : Strategy
    {
        public override void Clean()
        {
            Console.WriteLine("The dust has been wiped away; Vacuum cleaner used");
        }
    }
}
