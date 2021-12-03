namespace No_1
{
    abstract class ResidentalComponent
    {
        protected string name;
        protected double avgAge;

        public ResidentalComponent(string name)
        {
            this.name = name;
        }

        public abstract void Add(ResidentalComponent c);
        public abstract void Remove(ResidentalComponent c);
        public abstract double GetAverageAgeInfo();
        public abstract void Display(int depth);
    }
}
