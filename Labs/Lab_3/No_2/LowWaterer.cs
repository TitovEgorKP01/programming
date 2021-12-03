namespace No_2
{
    class LowWaterer : Waterer
    {
        public LowWaterer(double commonDose)
        {
            this.waterDose = commonDose * 0.5;
        }
    }
}
