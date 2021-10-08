using System;

namespace Lab_2
{
    interface IICECar
    {
        void FillCar(RefuelingOperator oper, FillingEventArgs fArgs);
    }

    class ICECar : Car, IICECar // car with internal combustion engine - авто с ДВС
    {
        protected double maxTankCapacity;
        protected double currentFuelLevel = 0;

        static ICECar()
        {
            carType = "ICE Car";
        }

        public ICECar(string name, string numbers, double maxTankCapacity) : base(name, numbers)
        {
            if (maxTankCapacity > 0)
            {
                this.maxTankCapacity = maxTankCapacity;    
            }
            else
            {
                this.maxTankCapacity = 0;
            }            
        }

        public ICECar() : base()
        {
            this.maxTankCapacity = 0;
        }

        void IICECar.FillCar(RefuelingOperator oper, FillingEventArgs fArgs)
        {
            if ((maxTankCapacity - currentFuelLevel) > fArgs.FillVolume)
            {
                currentFuelLevel += fArgs.FillVolume;

                double currPercentFill = currentFuelLevel / maxTankCapacity * 100;

                Console.WriteLine($"Car of [Owner: {ownerName}] filled by [Operator: {oper.Fullname}]. Current fill: {currPercentFill:f2} %");
            }
            else
            {
                currentFuelLevel = maxTankCapacity;

                Console.WriteLine($"Car of [Owner: {ownerName}] filled by [Operator: {oper.Fullname}]. Current fill: 100 %");
            }
        }

        public override string GetCarDescription()
        {
            return $"-- Car description: [Owner: {ownerName}]; [Numbers: {numbers}];\n [Type: {carType}] [Tank capacity: {maxTankCapacity} Litres]";
        }

        public override void Drive(double distance)
        {
            Console.WriteLine($"The ICE car drove {distance} km");
        }
    }
}
