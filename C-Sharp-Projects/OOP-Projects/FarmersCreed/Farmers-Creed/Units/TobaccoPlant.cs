namespace FarmersCreed.Units
{
    using System;

    public class TobaccoPlant : Plant
    {
        private const int BaseHealth = 12;
        private const int BaseGrowTime = 4;
        private const int BaseProductionQuantity = 10;

        public TobaccoPlant(string id)
            : base(id, TobaccoPlant.BaseHealth, TobaccoPlant.BaseProductionQuantity, TobaccoPlant.BaseGrowTime)
        {
        }

        public override Product GetProduct()
        {
            if (!this.HasGrown || !this.IsAlive)
            {
                throw new InvalidOperationException("The tobacco plant cannot produce while growing or dead.");
            }

            var product = new Product(this.ProductId, ProductType.Tobacco, this.ProductionQuantity);
            return product;
        }

        public override void Grow()
        {
            this.GrowTime -= 2;
        }
    }
}
