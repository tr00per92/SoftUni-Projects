namespace FarmersCreed.Units
{
    public abstract class FoodPlant : Plant
    {
        private const int WaterHealthEffect = 1;
        private const int WitherHealthEffect = -2;

        protected FoodPlant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity, growTime)
        {
        }

        public override void Water()
        {
            this.Health += FoodPlant.WaterHealthEffect;
        }

        public override void Wither()
        {
            this.Health += FoodPlant.WitherHealthEffect;
        }
    }
}
