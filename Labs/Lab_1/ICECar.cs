using System;

namespace Lab_1
{
    class ICECar : Car // car with internal combustion engine - авто с ДВС
    {
        protected double tankCapacity;

        static ICECar()
        {
            carType = "ICE Car";
        }

        public ICECar(string name, string numbers, double tankCapacity) : base(name, numbers)
        {
            if (tankCapacity > 0)
            {
                this.tankCapacity = tankCapacity;    
            }
            else
            {
                this.tankCapacity = 0;
            }            
        }

        public ICECar() : base()
        {
            this.tankCapacity = 0;
        }



        public override string CarDescription()
        {
            return $"-- Car description: [Owner: {ownerName}]; [Numbers: {numbers}];\n [Type: {carType}] [Tank capacity: {tankCapacity} Litres]";
        }
    
        ~ICECar()
        {
            Console.WriteLine("-- ICECar destructor called --");
        }
    }
}
