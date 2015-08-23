namespace FarmersCreed.Units
{
    using System;

    using Interfaces;

    public class Swine : Animal
    {
        private const int BaseHealth = 20;
        private const int BaseProductionQuantity = 1;
        private const int ProductHealthEffect = 5;
        private const int StarveHealthUpdate = -3;

        public Swine(string id)
            : base(id, Swine.BaseHealth, Swine.BaseProductionQuantity)
        {
        }

        public override void Eat(IEdible food, int quantity)
        {
            this.Health += 2 * food.HealthEffect * quantity;
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("A dead swine can't produce.");
            }

            this.Health = 0;

            var product = new Food(
                this.ProductId,
                ProductType.PorkMeat,
                FoodType.Meat,
                this.ProductionQuantity,
                Swine.ProductHealthEffect);
            return product;
        }

        public override void Starve()
        {
            this.Health += Swine.StarveHealthUpdate;
        }
    }
}
