namespace FractionalKnapsack
{
    public struct Item
    {
        public Item(int price, int weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public int Price { get; }

        public int Weight { get; }
    }
}
