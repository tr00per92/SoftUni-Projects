namespace FarmersCreed.Units
{
    using Interfaces;

    public abstract class FarmUnit : GameObject, IProductProduceable 
    {
        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
        }

        public int ProductionQuantity { get; set; }

        public int Health { get; set; }

        public bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
        }

        public string ProductId
        {
            get
            {
                return this.Id + "Product";
            }
        }

        public override string ToString()
        {
            return string.Format("--{0} {1}", this.GetType().Name, this.Id);
        }

        public abstract Product GetProduct();
    }
}
