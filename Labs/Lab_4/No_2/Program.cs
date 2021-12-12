namespace No_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Character character = new PlayableCharacter(); 

            character.GoUp();
            character.GoUp();
            character.GetDamage(66);

            Character savedCopyCharacter = character.Clone();

            character.GetDamage(34);

            savedCopyCharacter.GoUp();
        }
    }
}
