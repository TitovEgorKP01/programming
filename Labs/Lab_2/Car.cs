using System;

namespace Lab_2
{
    abstract class Car : IDisposable
    {
        protected string ownerName;
        protected string numbers;
        protected static string carType = "unknown";

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

        public virtual string GetCarDescription()
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
                    // Disposing managed resources
                }

                // Disposing unmanaged resources
                
                disposed = true;
            }
        }

        public string Type
        {
            get
            {
                return carType;
            }
        }

        public abstract void Drive(double distance);
    }
}
