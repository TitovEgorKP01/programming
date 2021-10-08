using System;

namespace Lab_2
{
    public class FillingEventArgs : EventArgs
    {
        private double fuelVolume;
        private double chargePower;


        public FillingEventArgs(double fuelVolume, double chargePower)
        {
            this.fuelVolume = fuelVolume;
            this.chargePower = chargePower;
        }

        public FillingEventArgs() : this(1, 1_000) {}

        public double FillVolume
        {
            get
            {
                return this.fuelVolume;
            }
            set
            {
                if (value > 0)
                {
                    this.fuelVolume = value;
                }
            }
        }

        public double Power
        {
            get
            {
                return chargePower;
            }
            set
            {
                if (value > 0)
                {
                    this.chargePower = value;
                }
            }
        }
    }
}
