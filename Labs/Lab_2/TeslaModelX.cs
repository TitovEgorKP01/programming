using System;

namespace Lab_2
{
    class TeslaModelX : ElectroCar, IElectroCar, ITeslaModelX
    {
        private DateTime productionDate;
        private double consumptionPerKm;

        private TeslaModelX() : base()
        {
            this.productionDate = DateTime.Now;
            this.ConsumptionPerKm = 0;
        }

        private TeslaModelX(string name, string numbers, double maxBatteryCapacity, double consumption) : base(name, numbers, maxBatteryCapacity)
        {
            this.productionDate = DateTime.Now;
            
            this.ConsumptionPerKm = consumption;
        }


        public static TeslaModelX GetCar(string name, string numbers, double maxBatteryCapacity, double consumption)
        {
            return new TeslaModelX(name, numbers, maxBatteryCapacity, consumption); 
        }

        public static TeslaModelX GetCar()
        {
            return new TeslaModelX(); 
        }


        public double Range
        {
            get
            {
                if (ConsumptionPerKm != 0)
                {
                    return maxBatteryCapacity / ConsumptionPerKm;
                }
                else
                {
                    return -1;
                }
            }
        }

        public double ConsumptionPerKm
        {
            get
            {
                return consumptionPerKm;
            }
            set
            {
                if (value > 0)
                {
                    this.consumptionPerKm = value;
                }
                else
                {
                    this.consumptionPerKm = 0;
                }
            }
        }

        public void RemoteOpenDoor(int doorNumber)
        {
            if (doorNumber < 1)
            {
                Console.WriteLine("Rear trunk opened");
            }
            else if (doorNumber > 4)
            {
                Console.WriteLine("Front trunk opened");
            }
            else
            {
                Console.WriteLine($"Door {doorNumber} opened");
            }
        }


        public override string GetCarDescription()
        {
            return $"-- Car description: - [Owner: {ownerName}] - [Numbers: {numbers}] -\n" + 
            $"- [Type: {carType}] - [Battery capacity: {maxBatteryCapacity} Watt * Hour] -\n" + 
            $"- [Production Date: {productionDate.ToString("d")}] -";
        }
    
        public override void Drive(double distance)
        {   
            Console.WriteLine($"Tesla Model X drove {distance} km");
        }
    }
}
