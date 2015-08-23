namespace FarmersCreed.Units
{
    using Interfaces;

    public abstract class Animal : FarmUnit
    {
        private const int StarveHealthUpdate = -1;

        protected Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public virtual void Starve()
        {
            this.Health += Animal.StarveHealthUpdate;
        }

        public override string ToString()
        {
            if (this.IsAlive)
            {
                return base.ToString() + ", Health: " + this.Health;
            }
            else
            {
                return base.ToString() + ", DEAD";
            }
        }

        public abstract void Eat(IEdible food, int quantity);
    }
}
