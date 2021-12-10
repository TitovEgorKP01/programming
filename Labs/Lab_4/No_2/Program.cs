using System;

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

    interface State
    {
        void GoUp();
        void GoDown();

        void GetDamage(double damage);
        bool GetLifeInfo();
        State GetStateCopy();
    }

    class PlayerState : State
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

        public double HP()
        {
            return hp;
        }

        public double GetPosY()
        {
            return posY;
        }
    
        public State GetStateCopy()
        {
            PlayerState copy = new PlayerState(_character);

            copy.posY = posY;
            copy.hp = hp;
            copy.isAlive = isAlive;

            return copy;
        }
    }

    class Character
    {
        private State _currentState;
        private State _savedState;
        private bool isSaved = false;

        public Character()
        {
            _currentState = new PlayerState(this);
        }

        public void ChangeState(State state)
        {
            _currentState = state;
        }

        public void GoUp()
        {
            if (_currentState != null)
            {
                _currentState.GoUp();
            }
        }
    
        public void GoDown()
        {
            if (_currentState != null)
            {
                _currentState.GoDown();
            }
        }

        public void GetDamage(double damage)
        {
            if (_currentState != null)
            {
                _currentState.GetDamage(damage);
            }

            CheckLifeState();
        }

        public void SaveState()
        {
            if (isSaved == false && _currentState.GetLifeInfo() != false)
            {
                Console.WriteLine("Character state saved");

                isSaved = true;

                _savedState = _currentState.GetStateCopy();  
            }
        }

        private void CheckLifeState()
        {
            if (_currentState.GetLifeInfo() == false)
            {
                if (_savedState != null)
                {
                    Console.WriteLine("Loading saved state...");

                    _currentState = _savedState;
                }
                else
                {
                    Console.WriteLine("No saved states. Game over.");
                }
            }
        }
    }
}
