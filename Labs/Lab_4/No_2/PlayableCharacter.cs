using System;

namespace No_2
{
    class PlayableCharacter : Character
    {
        public PlayableCharacter()
        {
            hp = 100;
            posY = 0;
            isAlive = true;
            isSaved = false;
        }

        public override void GetDamage(double damage)
        {
            if (isAlive)
            {
                hp -= damage;

                Console.WriteLine($"Character get damaged. Current hp: '{hp}'");

                CheckState();
            }
        }

        private void CheckState()
        {
            if (hp <= 0)
            {
                isAlive = false;

                Console.WriteLine($"Character died");
            }
        }

        public override void GoDown()
        {
            if (isAlive)
            {
                posY -= 10;

                Console.WriteLine($"Character went down. Current position: '{posY}'");  
            }
        }

        public override void GoUp()
        {
            if (isAlive)
            {
                posY += 10;

                Console.WriteLine($"Character went up. Current position: '{posY}'");
            }
        }

        public override Character Clone()
        {
            if (isSaved)
            {
                Console.WriteLine("Character copy already saved.");

                return null;
            }
            else
            {
                isSaved = true;

                Console.WriteLine("Character copy saved");

                return (Character)this.MemberwiseClone();
            }
        }
    }
}
