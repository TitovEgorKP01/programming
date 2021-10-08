using System;

namespace Lab_2
{
    class ElectroCar : Car, IElectroCar
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


        void IElectroCar.ChargeCar(RefuelingOperator oper, FillingEventArgs fArgs)
        {
            Action<RefuelingOperator> newClientReact = oper => Console.WriteLine($"[{oper.Fullname}] see new client car, it's [Electric car]");

            newClientReact(oper);

            Func<double, double, double> calcPercent = (currValue, maxValue) => currValue / maxValue * 100;

            if ((maxBatteryCapacity - currentChargeLevel) > fArgs.Power)
            {
                currentChargeLevel += fArgs.Power;

                double currPercentCharge = calcPercent(currentChargeLevel, maxBatteryCapacity);

                Console.WriteLine($"Car of [Owner: {ownerName}] charged by [Operator: {oper.Fullname}]. Current charge: {currPercentCharge:f2} %");
            }
            else
            {
                currentChargeLevel = maxBatteryCapacity;

                Console.WriteLine($"Car of [Owner: {ownerName}] charged by [Operator: {oper.Fullname}]. Current charge: 100 %");
            }

            Console.WriteLine();
        }


        public override string GetCarDescription()
        {
            return $"-- Car description: [Owner: {ownerName}]; [Numbers: {numbers}];\n [Type: {carType}] [Battery capacity: {maxBatteryCapacity} Watt * Hour]";
        }


        public override void Drive(double distance)
        {
            Console.WriteLine($"The electric car drove {distance} km");
        }
    }
}
