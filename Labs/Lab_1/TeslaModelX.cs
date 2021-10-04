using System;

namespace Lab_1
{
    class TeslaModelX : ElectroCar
    {
        private DateTime productionDate;
        private double consumptionPerKm;

        private TeslaModelX() : base()
        {
            this.productionDate = DateTime.Now;
            this.ConsumptionPerKm = 0;
        }

        private TeslaModelX(string name, string numbers, double batteryCapacity, double consumption) : base(name, numbers, batteryCapacity)
        {
            this.productionDate = DateTime.Now;
            
            this.ConsumptionPerKm = consumption;
        }


        public static TeslaModelX GetCar(string name, string numbers, double batteryCapacity, double consumption)
        {
            return new TeslaModelX(name, numbers, batteryCapacity, consumption); 
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
                    return batteryCapacity / ConsumptionPerKm;
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
                return ConsumptionPerKm;
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


        public override string CarDescription()
        {
            return $"-- Car description: - [Owner: {ownerName}] - [Numbers: {numbers}] -\n" + 
            $"- [Type: {carType}] - [Battery capacity: {batteryCapacity} Watt * Hour] -\n" + 
            $"- [Production Date: {productionDate.ToString("d")}] -";
        }

        ~TeslaModelX()
        {
            Console.WriteLine("-- TeslaModelX destructor called --");
        }
    }
}
