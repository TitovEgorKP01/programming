using System;

namespace Lab_2
{
    public class RefuelingOperator
    {
        public event FillingHandle FillingEvent;
        public FillingEventArgs fArgs;
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

                fillArgs = new FillingEventArgs(volume, power);
            }
            catch (Exception ex)
            {
                Console.WriteLine("".PadRight(83, '#'));
                Console.WriteLine(ex.Message);
                Console.WriteLine("Set to default values: [Fill volume: 1 liter]; [Charge power: 1_000 Watt]");
                Console.WriteLine("".PadRight(83, '#'));

                fillArgs = new FillingEventArgs();
            }
            finally
            {
                fArgs = fillArgs;

                Console.WriteLine();

                Console.WriteLine($"Operator {this.name} is responsible for filling cars.");

                Console.WriteLine();

                if (FillingEvent != null)
                {
                    FillingEvent((RefuelingOperator)this, fillArgs);
                }   
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
