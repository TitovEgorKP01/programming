using System;

namespace Lab_2
{
    public class RefuelingOperator
    {
        public event FillingHandle FillingEvent;
        private string name;
        private string surname;

        public RefuelingOperator()
        {
            this.name = "unknown";
            this.surname = "";
        }

        public RefuelingOperator(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public void FillUp()
        {
            double volume, power;
            FillingEventArgs fillArgs = null;
        
            try
            {
                Console.Write("Enter filling volume: ");
                volume = Double.Parse(Console.ReadLine());

                Console.Write("Enter charge power: ");
                power = Double.Parse(Console.ReadLine());

                if (volume <= 0 || power <= 0)
                {
                    throw new ArgumentException();
                }

                fillArgs = new FillingEventArgs(volume, power);
            }
            catch
            {
                Console.WriteLine("".PadRight(83, '#'));
                Console.WriteLine("Incorrect values entered. Set to default values");
                Console.WriteLine("".PadRight(83, '#'));

                fillArgs = new FillingEventArgs();
            }

            // Console.WriteLine();

            Console.WriteLine($"Operator {this.name} is responsible for filling cars.");

            // Console.WriteLine();

            if (FillingEvent != null)
            {
                FillingEvent((RefuelingOperator)this, fillArgs);
            }
        }
    
        public string Fullname
        {
            get
            {
                return $"{this.name} {this.surname}";
            }
        }
    }

    public class FillingEventArgs : EventArgs
    {
        private double fuelVolume;
        private double chargePower;


        public FillingEventArgs(double fuelVolume, double chargePower)
        {
            this.fuelVolume = fuelVolume;
            this.chargePower = chargePower;
        }

        public FillingEventArgs() : this(1, 1_000) {}

        public double FillVolume
        {
            get
            {
                return this.fuelVolume;
            }
            set
            {
                if (value > 0)
                {
                    this.fuelVolume = value;
                }
            }
        }

        public double Power
        {
            get
            {
                return chargePower;
            }
            set
            {
                if (value > 0)
                {
                    this.chargePower = value;
                }
            }
        }
    }

    class FillStation
    {
        public FillStation(RefuelingOperator oper)
        {
            IElectroCar[] eCars = new ElectroCar[2];
            eCars[0] = TeslaModelX.GetCar();
            eCars[1] = TeslaModelX.GetCar("Gregory", "OO0000OO", 100_000, 24_000);

            IICECar[] iceCars = new ICECar[2];
            iceCars[0] = MazdaMX5.GetCar();
            iceCars[1] = MazdaMX5.GetCar("StickMan", "JJ9999JJ", 40, 4);

            for (int i = 0; i < 2; i++)
            {
                oper.FillingEvent += new FillingHandle(eCars[i].ChargeCar);

                oper.FillingEvent += new FillingHandle(iceCars[i].FillCar);
            }
        }
    }

    public delegate void FillingHandle(RefuelingOperator oper, FillingEventArgs chargs);


    class Program
    {
        static void Main(string[] args)
        {
            RefuelingOperator oper = new RefuelingOperator("Taras", "Bulba");

            FillStation station = new FillStation(oper);

            oper.FillUp();
        }
    }
}
