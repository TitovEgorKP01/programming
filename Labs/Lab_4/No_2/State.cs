namespace No_2
{
    interface State
    {
        void GoUp();
        void GoDown();

        void GetDamage(double damage);
        bool GetLifeInfo();
        State GetStateCopy();
    }
}
