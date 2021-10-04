using System;

namespace Lab_1
{
    class ElectroCar : Car
    {
        protected double maxBatteryCapacity;
        protected double currentChargeLevel = 0;

        static ElectroCar()
        {
            carType = "Electric Car";
        }

        public ElectroCar(string name, string numbers, double maxBatteryCapacity) : base(name, numbers)
        {
            if (maxBatteryCapacity > 0)
            {
                this.maxBatteryCapacity = maxBatteryCapacity;    
            }
            else
            {
                this.maxBatteryCapacity = 0;
            }            
        }

        public ElectroCar() : base()
        {
            this.maxBatteryCapacity = 0;
        }

        
        public void ChargeCar(double chargeAmount)
        {
            if ((maxBatteryCapacity - currentChargeLevel) > chargeAmount)
            {
                currentChargeLevel += chargeAmount;
            }
            else
            {
                currentChargeLevel = maxBatteryCapacity;
            }
        }


        public override string GetCarDescription()
        {
            return $"-- Car description: [Owner: {ownerName}]; [Numbers: {numbers}];\n [Type: {carType}] [Battery capacity: {maxBatteryCapacity} Watt * Hour]";
        }
    
        ~ElectroCar()
        {
            Console.WriteLine("-- ElectroCar destructor called --");
        }
    }
}
