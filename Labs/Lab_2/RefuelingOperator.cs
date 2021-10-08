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
}
