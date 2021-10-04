using System;

namespace Lab_1
{
    class ICECar : Car // car with internal combustion engine - авто с ДВС
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

        public void FillCar(double fuelAmount)
        {
            if ((maxTankCapacity - currentFuelLevel) > fuelAmount)
            {
                currentFuelLevel += fuelAmount;
            }
            else
            {
                currentFuelLevel = maxTankCapacity;
            }
        }

        public override string GetCarDescription()
        {
            return $"-- Car description: [Owner: {ownerName}]; [Numbers: {numbers}];\n [Type: {carType}] [Tank capacity: {maxTankCapacity} Litres]";
        }
    
        ~ICECar()
        {
            Console.WriteLine("-- ICECar destructor called --");
        }
    }
}
