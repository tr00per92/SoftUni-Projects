namespace FarmersCreed.Units
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;

    public class Farm : GameObject, IFarm
    {
        public Farm(string id)
            : base(id)
        {
            this.Plants = new List<Plant>();
            this.Animals = new List<Animal>();
            this.Products = new List<Product>();
        }

        public List<Plant> Plants { get; set; }

        public List<Animal> Animals { get; set; }

        public List<Product> Products { get; private set; }

        public void AddProduct(Product product)
        {
            var existingProduct = this.Products.FirstOrDefault(pr => pr.Id == product.Id);

            if (existingProduct == null)
            {
                this.Products.Add(product);
            }
            else
            {
                existingProduct.Quantity += product.Quantity;
            }
        }

        public void Exploit(IProductProduceable productProducer)
        {
            productProducer.GetProduct();
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            this.Plants.ForEach(plant => plant.Update());
            this.Animals.ForEach(animal => animal.Starve());
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());

            this.Animals
                .Where(animal => animal.IsAlive)
                .OrderBy(animal => animal.Id)
                .ToList()
                .ForEach(animal => result.AppendLine(animal.ToString()));
            this.Plants
                .Where(plant => plant.IsAlive)
                .OrderBy(plant => plant.Health)
                .ThenBy(plant => plant.Id)
                .ToList()
                .ForEach(plant => result.AppendLine(plant.ToString()));
            this.Products
                .OrderBy(product => product.ProductType.ToString())
                .ThenByDescending(product => product.Quantity)
                .ThenBy(product => product.Id)
                .ToList()
                .ForEach(product => result.AppendLine(product.ToString()));

            return result.ToString();
        }
    }
}
