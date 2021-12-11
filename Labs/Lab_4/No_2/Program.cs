namespace No_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character(); 

            character.GoUp();
            character.GoUp();
            character.GetDamage(66);

            character.SaveState();

            character.GetDamage(44);

            character.GoUp();
        }
    }
}
