using System;
using System.Collections.Generic;

namespace No_1
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class ResidentalComponent
    {
        protected string name;
        protected int electro;

        public ResidentalComponent(string name)
        {
            this.name = name;
        }

        public abstract void Add(ResidentalComponent c);
        public abstract void Remove(ResidentalComponent c);
        public abstract int GetAnimalInfo();
        public abstract double GetAverageAge();
        public abstract void Display(int depth);
    }

    class Composite : ResidentalComponent
    {
        private List<ResidentalComponent> _children = new List<ResidentalComponent>();

        public Composite(string name) : base(name) 
        {
            this.electro = 0;
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
            Console.WriteLine(new String('-', depth) + name + " " + this.electro.ToString());

            foreach (ResidentalComponent component in _children)
            {
                component.Display(depth + 2);
            }
        }
     
        public override int GetAnimalInfo()
        {
            this.electro = 0;

            foreach (ResidentalComponent component in _children)
            {
                this.electro += component.GetAnimalInfo();
            }            
            return this.electro;
        }

        public override double GetAverageAge()
        {
            throw new NotImplementedException();
        }
    }

    class Flat : ResidentalComponent
    {
        public Flat(string name) : base(name)
        {
            Random rnd = new Random();

            this.electro = rnd.Next(150);
        }

        public override void Add(ResidentalComponent c)
        {
            Console.WriteLine("Impossible operation");
        }

        public override void Remove(ResidentalComponent c)
        {
            Console.WriteLine("Impossible operation");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name + " " + electro.ToString());
        }

        public override int GetAnimalInfo()
        {
            return this.electro;
        }

        public override double GetAverageAge()
        {
            throw new NotImplementedException();
        }
    }
}
