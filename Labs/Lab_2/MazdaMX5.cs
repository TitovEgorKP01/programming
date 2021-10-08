using System;

namespace Lab_2
{
    interface IMazdaMX5
    {
        void OpenRoof();
    }

    class MazdaMX5 : ICECar, IICECar, IMazdaMX5
    {
        private DateTime productionDate;
        private double consumptionPerKm;

        private MazdaMX5() : base()
        {
            this.productionDate = DateTime.Now;
            this.ConsumptionPerKm = 0;
        }

        private MazdaMX5(string name, string numbers, double tankCapacity, double consumption) : base(name, numbers, tankCapacity)
        {
            this.productionDate = DateTime.Now;
            
            this.ConsumptionPerKm = consumption;
        }


        public static MazdaMX5 GetCar(string name, string numbers, double tankCapacity, double consumption)
        {
            return new MazdaMX5(name, numbers, tankCapacity, consumption); 
        }

        public static MazdaMX5 GetCar()
        {
            return new MazdaMX5(); 
        }


        public double Range
        {
            get
            {
                if (ConsumptionPerKm != 0)
                {
                    return maxTankCapacity / ConsumptionPerKm;
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

        public void OpenRoof()
        {
            Console.WriteLine("Roof opened");
        }


        public override string GetCarDescription()
        {
            return $"-- Car description: - [Owner: {ownerName}] - [Numbers: {numbers}] -\n" + 
            $"- [Type: {carType}] - [Tank capacity: {maxTankCapacity} Litres] -\n" + 
            $"- [Production Date: {productionDate.ToString("d")}] -";
        }
    
        public override void Drive(double distance)
        {   
            Console.WriteLine($"Mazda MX5 drove {distance} km");
        }
    }
}
