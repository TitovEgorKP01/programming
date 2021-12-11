using System;

namespace No_2
{
    class Character
    {
        private IState _currentState;
        private IState _savedState;
        private bool isSaved = false;

        public Character()
        {
            _currentState = new PlayerState(this);
        }

        public void ChangeState(IState state)
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
