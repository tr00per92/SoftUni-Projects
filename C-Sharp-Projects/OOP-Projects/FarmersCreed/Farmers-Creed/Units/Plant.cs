namespace FarmersCreed.Units
{
    public abstract class Plant : FarmUnit
    {
        private const int WaterHealthEffect = 2;
        private const int WitherHealthEffect = -1;

        protected Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public int GrowTime { get; protected set; }

        public bool HasGrown
        {
            get
            {
                return this.GrowTime <= 0;
            }
        }

        public void Update()
        {
            if (this.HasGrown)
            {
                this.Wither();
            }
            else
            {
                this.Grow();
            }
        }

        public virtual void Water()
        {
            this.Health += Plant.WaterHealthEffect;
        }

        public virtual void Grow()
        {
            this.GrowTime--;
        }

        public virtual void Wither()
        {
            this.Health += Plant.WitherHealthEffect;
        }

        public override string ToString()
        {
            if (this.IsAlive)
            {
                return base.ToString() + string.Format(", Health: {0}, Grown: {1}",
                    this.Health, this.HasGrown ? "Yes" : "No");
            }
            else
            {
                return base.ToString() + ", DEAD";
            }
        }
    }
}
