using System;
using System.Collections.Generic;

namespace No_1
{
    class Flat : ResidentalComponent
    {
        private List<Animal> _animals = new List<Animal>();

        public Flat(string name) : base(name)
        {
            
        }

        public override void Add(ResidentalComponent c)
        {
            Console.WriteLine("Impossible operation");
        }
        public override void Remove(ResidentalComponent c)
        {
            Console.WriteLine("Impossible operation");
        }

        public void AddAnimal(Animal an)
        {
            _animals.Add(an);
        }
        public void RemoveAnimal(Animal an)
        {
            _animals.Remove(an);
        }


        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + " " + name + ". Average animals age: " + avgAge.ToString());
        }

        public override double GetAverageAgeInfo()
        {
            this.avgAge = 0;
            double totalAge = 0;
            int totalCount = 0;

            foreach (Animal animal in _animals)
            {
                double animalAge = animal.Age;

                if (animalAge != 0)
                {
                    totalAge += animalAge;

                    totalCount++;
                }
            }      

            if (totalCount != 0)
            {
                this.avgAge = totalAge / totalCount;
            }      

            return this.avgAge;
        }
    }
}
