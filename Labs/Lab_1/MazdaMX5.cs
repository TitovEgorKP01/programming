using System;

namespace Lab_1
{
    class MazdaMX5 : ICECar
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
                    return tankCapacity / ConsumptionPerKm;
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


        public override string CarDescription()
        {
            return $"-- Car description: - [Owner: {ownerName}] - [Numbers: {numbers}] -\n" + 
            $"- [Type: {carType}] - [Tank capacity: {tankCapacity} Litres] -\n" + 
            $"- [Production Date: {productionDate.ToString("d")}] -";
        }
    
        ~MazdaMX5()
        {
            Console.WriteLine("-- MazdaMX5 destructor called --");
        }
    }
}
