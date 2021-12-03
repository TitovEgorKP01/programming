using System;

namespace No_2
{
    abstract class Waterer
    {
        protected double waterDose;

        public void ToWater(string flowerName)
        {
            Console.WriteLine($"Waterer pour flower '{flowerName}' with dose '{waterDose}'");
        }
    }
}
