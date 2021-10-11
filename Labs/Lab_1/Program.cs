using System;

namespace Lab_1
{
    class Program
    {
        static void Main()
        {
            Car car = new Car("Ivan", "OO0000OO");
            
            ElectroCar eCar = new ElectroCar("Ivan", "OO0000OO", 100_000);

            ICECar iceCar = new ICECar("Ivan", "OO0000OO", 40);


            MazdaMX5 mazda = MazdaMX5.GetCar("Ivan", "OO0000OO", 40, 4);

            DisposeCars();

            Console.WriteLine("\nMemory before creating 10_000 obj: " + GC.GetTotalMemory(false));
            

            for (int i = 0; i < 10_000; i++)
            {            
                Car car1 = new Car();

                car1.Dispose();
            }

            Console.WriteLine($"Memory after creating 10_000 obj: {GC.GetTotalMemory(false)}\n");
            Console.WriteLine($"Generation of 'mazda' obj before collecting: {GC.GetGeneration(mazda)}\n");

            GC.Collect(2);
            GC.WaitForPendingFinalizers();
            
            Console.WriteLine($"Memory after collecting garbage: {GC.GetTotalMemory(false)}\n");
            Console.WriteLine($"Generation of 'mazda' obj after collecting: {GC.GetGeneration(mazda)}\n");
            Console.WriteLine($"Garbage Collection count: {GC.CollectionCount(0)}");
        }

        private static void DisposeCars()
        {
            TeslaModelX tesla = TeslaModelX.GetCar(60_000);

            tesla.Dispose();

            GC.ReRegisterForFinalize(tesla);


            MazdaMX5 mazda = MazdaMX5.GetCar();

            mazda.Dispose();

            GC.ReRegisterForFinalize(mazda);
        }
    }
}

