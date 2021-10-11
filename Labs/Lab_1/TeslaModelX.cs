using System;

namespace Lab_1
{
    class TeslaModelX : ElectroCar
    {
        private DateTime productionDate;
        private double consumptionPerKm;
        static double carPrice = 60_000;

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


        public static TeslaModelX GetCar(string name, string numbers, double maxBatteryCapacity, double consumption, double clientPay)
        {
            if (clientPay < carPrice)
            {
                return new TeslaModelX(name, numbers, maxBatteryCapacity, consumption);
            }
            else
            {
                Console.WriteLine("Not enough money to buy TeslaModelX");

                return null;
            }             
        }

        public static TeslaModelX GetCar(double clientPay)
        {
            if (clientPay < carPrice)
            {
                return new TeslaModelX();
            }
            else
            {
                Console.WriteLine("Not enough money to buy TeslaModelX");

                return null;
            } 
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

        ~TeslaModelX()
        {
            Console.WriteLine("-- TeslaModelX destructor called --");
        }
    }
}
