namespace No_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Composite buildings = new Composite("All buildings");

            Composite build1 = new Composite("Building #1");
            Composite build2 = new Composite("Building #2");
            buildings.Add(build1);
            buildings.Add(build2); 

            Composite entr1 = new Composite("Entrance #1");
            Composite entr2 = new Composite("Entrance #2");
            Composite entr3 = new Composite("Entrance #3");
            build1.Add(entr1);
            build1.Add(entr2);
            build2.Add(entr3);

            Flat fl1 = new Flat("Flat #1");
            Flat fl2 = new Flat("Flat #2");
            Flat fl3 = new Flat("Flat #3");
            Flat fl4 = new Flat("Flat #4");
            entr1.Add(fl1);
            entr2.Add(fl2);
            entr2.Add(fl3);
            entr3.Add(fl4);
            
            Dog dog1 = new Dog("Reks", 10);
            Dog dog2 = new Dog("Akbar", 5);
            Dog dog3 = new Dog("Sharik", 3);
            Dog dog4 = new Dog("Mops", 15);
            Cat cat1 = new Cat("Nami", 2);
            Cat cat2 = new Cat("Pirate", 6);
            Cat cat3 = new Cat("Murka", 5);
            Cat cat4 = new Cat("Abel", 10);
            
            fl1.AddAnimal(dog1);
            fl1.AddAnimal(dog2);
            fl1.AddAnimal(cat1);

            fl2.AddAnimal(dog3);
            fl2.AddAnimal(cat2);
            fl2.AddAnimal(cat3);

            fl3.AddAnimal(dog4);
            fl3.AddAnimal(cat4);

            buildings.GetAverageAgeInfo();
            buildings.Display(2);
        }
    }
}
