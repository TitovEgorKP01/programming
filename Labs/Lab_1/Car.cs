using System;

namespace Lab_1
{
    class Car : IDisposable
    {
        protected string ownerName;
        protected string numbers;
        protected static string carType;

        protected bool disposed;


        public Car()
        {
            this.ownerName = "unknown";
            this.numbers = "unknown";
        }

        public Car(string name, string numbers)
        {
            this.ownerName = name;
            this.numbers = numbers;
        }

        public virtual string CarDescription()
        {
            return $"-- Car description: [Owner: {ownerName}]; [Numbers: {numbers}]";
        }

        public virtual void Dispose()
        {
            CleanUp(true);
         
            GC.SuppressFinalize(this);
        }

        protected void CleanUp(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Console.WriteLine("-- Managed resourses disposed --");
                }

                // Console.WriteLine("-- Unmanaged resourses disposed --");
                
                disposed = true;
            }
        }

        ~Car()
        {
            CleanUp(false);

            Console.WriteLine("-- Car destructor called --");
        }
    }
}
