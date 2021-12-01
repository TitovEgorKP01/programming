namespace No_1
{
    abstract class Animal
    {
        protected string name;
        protected int age;
        protected string kind = "unknown kind";

        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string GetDescription()
        {
            return $"{kind} '{name}'. Age: '{age}'";
        }
    }
}
