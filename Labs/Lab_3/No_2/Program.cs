namespace No_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double commonWaterDose = 1;

            Flower fl1 = new Flower("Rose", "positive");
            Flower fl2 = new Flower("Cactus", "negative");
            Flower fl3 = new Flower("Romashka", "common");

            Waterer low = new LowWaterer(commonWaterDose);
            Waterer common = new CommonWaterer(commonWaterDose);
            Waterer strong = new StrongWaterer(commonWaterDose);

            SuperWaterer superWaterer = new SuperWaterer(low, common, strong);

            superWaterer.ToWater(fl1);
            superWaterer.ToWater(fl2);
            superWaterer.ToWater(fl3);
        }
    }
}
