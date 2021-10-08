using System;

namespace Lab_2
{
    static class TeslaExtension
    {
        public static void OnPartyMode(this TeslaModelX tesla)
        {
            Console.WriteLine("Party mode is on");
        }
    }
}
