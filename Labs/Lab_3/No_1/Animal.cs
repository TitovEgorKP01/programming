using System;

namespace No_1
{
    abstract class Animal
    {
        protected string name;
        protected double age;
        protected string kind = "unknown kind";

        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public double Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age > 0)
                {
                    this.age = value;
                }  
                else
                {
                    Console.WriteLine("Incorrect age value entered");
                }              
            }
        }

        public string GetDescription()
        {
            return $"{kind} '{name}'. Age: '{age}'";
        }
    }
}
