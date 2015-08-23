namespace FarmersCreed.Units
{
    using System;

    using Interfaces;

    public class Cow : Animal
    {
        private const int BaseHealth = 15;
        private const int BaseProductionQuantity = 6;
        private const int ProductHealthEffect = 4;

        public Cow(string id)
            : base(id, Cow.BaseHealth, Cow.BaseProductionQuantity)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("A dead cow can't produce.");
            }

            this.Health -= 2;

            var product = new Food(
                this.ProductId,
                ProductType.Milk,
                FoodType.Organic,
                this.ProductionQuantity,
                Cow.ProductHealthEffect);
            return product;
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.FoodType == FoodType.Meat)
            {
                this.Health -= food.HealthEffect * quantity;
            }
            else
            {
                this.Health += food.HealthEffect * quantity;
            }
        }
    }
}
