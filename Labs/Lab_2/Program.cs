using System;

namespace Lab_2
{
    public delegate void FillingHandle(RefuelingOperator oper, FillingEventArgs fArgs);


    class Program
    {
        static void Main(string[] args)
        {
            RefuelingOperator oper = new RefuelingOperator("Taras", "Bulba");

            FillStation station = new FillStation(oper);

            oper.FillUp();

            
            FillingHandle currentFillInfo = delegate(RefuelingOperator oper, FillingEventArgs fArgs)
            {
                Console.WriteLine($"Current filling/charging operator: [{oper.Fullname}]; Current filling volume: [{fArgs.FillVolume}] litres; Current charging power: [{fArgs.Power}] Watt");
            };
            
            currentFillInfo(oper, oper.fArgs);

            Console.WriteLine();

            TeslaModelX tesla = TeslaModelX.GetCar("owner", "numbers", 1_000_000, 1);
            tesla.OnPartyMode();
        }
    }
}
