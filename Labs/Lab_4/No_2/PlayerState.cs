using System;

namespace No_2
{
    class PlayerState : IState
    {
        private Character _character;
        private double posY = 0;
        private double hp = 100;
        private bool isAlive = true;

        public PlayerState(Character character)
        {
            _character = character;
        }

        public void GoDown()
        {
            if (isAlive)
            {
                posY -= 10;

                Console.WriteLine($"Character went down. Current position: '{posY}'");  
            }
        }

        public void GoUp()
        {
            if (isAlive)
            {
                posY += 10;

                Console.WriteLine($"Character went up. Current position: '{posY}'");
            }
        }

        public void GetDamage(double damage)
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
    
        public bool GetLifeInfo()
        {   
            return isAlive;
        }

        public double GetHP()
        {
            return hp;
        }

        public double GetPosY()
        {
            return posY;
        }
    
        public IState GetStateCopy()
        {
            PlayerState copy = new PlayerState(_character);

            copy.posY = posY;
            copy.hp = hp;
            copy.isAlive = isAlive;

            return copy;
        }
    }
}
