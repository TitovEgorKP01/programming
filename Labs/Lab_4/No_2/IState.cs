namespace No_2
{
    interface IState
    {
        void GoUp();
        void GoDown();

        void GetDamage(double damage);
        bool GetLifeInfo();
        IState GetStateCopy();
    }
}
