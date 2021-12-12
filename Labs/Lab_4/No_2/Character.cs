namespace No_2
{
    abstract class Character
    {
        protected double posY;
        protected double hp;
        protected bool isAlive;
        protected bool isSaved;

        public abstract void GoUp();
        public abstract void GoDown(); 
        public abstract void GetDamage(double damage);
        
        public abstract Character Clone();
    }
}
