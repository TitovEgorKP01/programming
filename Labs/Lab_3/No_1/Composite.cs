using System;
using System.Collections.Generic;

namespace No_1
{
    class Composite : ResidentalComponent
    {
        private List<ResidentalComponent> _children = new List<ResidentalComponent>();

        public Composite(string name) : base(name) 
        {
            this.avgAge = 0;
        }

        public override void Add(ResidentalComponent component)
        {
            _children.Add(component);
        }

        public override void Remove(ResidentalComponent component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + " " + name + ". Average animals age: " + this.avgAge.ToString());

            foreach (ResidentalComponent component in _children)
            {
                component.Display(depth + 2);
            }
        }
     
        public override double GetAverageAgeInfo()
        {
            this.avgAge = 0;
            double totalAge = 0;
            int totalCount = 0;

            foreach (ResidentalComponent component in _children)
            {
                double compAvgAge = component.GetAverageAgeInfo();

                if (compAvgAge != 0)
                {
                    totalAge += compAvgAge;

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
