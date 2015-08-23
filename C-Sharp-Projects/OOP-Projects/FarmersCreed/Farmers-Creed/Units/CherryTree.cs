namespace FarmersCreed.Units
{
    using System;

    public class CherryTree : FoodPlant
    {
        private const int BaseHealth = 14;
        private const int BaseGrowTime = 3;
        private const int BaseProductionQuantity = 4;
        private const int ProductHealthEffect = 2;

        public CherryTree(string id)
            : base(id, CherryTree.BaseHealth, CherryTree.BaseProductionQuantity, CherryTree.BaseGrowTime)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("The cherry cannot produce while dead.");
            }

            var product = new Food(
                this.ProductId,
                ProductType.Cherry,
                FoodType.Organic,
                this.ProductionQuantity,
                CherryTree.ProductHealthEffect);
            return product;
        }
    }
}
