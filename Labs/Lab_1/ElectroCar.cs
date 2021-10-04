using System;

namespace Lab_1
{
    class ElectroCar : Car
    {
        protected double batteryCapacity;

        static ElectroCar()
        {
            carType = "Electric Car";
        }

        public ElectroCar(string name, string numbers, double batteryCapacity) : base(name, numbers)
        {
            if (batteryCapacity > 0)
            {
                this.batteryCapacity = batteryCapacity;    
            }
            else
            {
                this.batteryCapacity = 0;
            }            
        }

        public ElectroCar() : base()
        {
            this.batteryCapacity = 0;
        }



        public override string CarDescription()
        {
            return $"-- Car description: [Owner: {ownerName}]; [Numbers: {numbers}];\n [Type: {carType}] [Battery capacity: {batteryCapacity} Watt * Hour]";
        }
    
        ~ElectroCar()
        {
            Console.WriteLine("-- ElectroCar destructor called --");
        }
    }
}
