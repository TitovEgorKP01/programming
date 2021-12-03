namespace No_2
{
    class StrongWaterer : Waterer
    {
        public StrongWaterer(double commonDose)
        {
            this.waterDose = commonDose + commonDose * 0.3;
        }
    }
}
