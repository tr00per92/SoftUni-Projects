namespace FarmersCreed.Simulator
{
    using System;

    using Interfaces;
    using Units;

    public class UpdatedFarmSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');
            string action = inputCommands[0];

            switch (action)
            {
                case "feed":
                    this.ExecuteFeedCommand(inputCommands);
                    break;
                case "water":
                    this.ExecuteWaterCommand(inputCommands[1]);
                    break;
                case "exploit":
                    this.ExecuteExploitCommand(inputCommands);
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }
        }

        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                    this.farm.Plants.Add(new CherryTree(id));
                    break;
                case "TobaccoPlant":
                    this.farm.Plants.Add(new TobaccoPlant(id));
                    break;
                case "Cow":
                    this.farm.Animals.Add(new Cow(id));
                    break;
                case "Swine":
                    this.farm.Animals.Add(new Swine(id));
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }

        private void ExecuteExploitCommand(string[] inputCommands)
        {
            IProductProduceable productProduceable;
            switch (inputCommands[1])
            {
                case "animal":
                    productProduceable = this.GetAnimalById(inputCommands[2]);
                    break;
                case "plant":
                    productProduceable = this.GetPlantById(inputCommands[2]);
                    break;
                default:
                    throw new InvalidOperationException("Only plants and animals can be exploited.");
            }

            var product = productProduceable.GetProduct();
            this.farm.AddProduct(product);
        }

        private void ExecuteFeedCommand(string[] inputCommands)
        {
            var animal = this.GetAnimalById(inputCommands[1]);
            var food = this.GetProductById(inputCommands[2]) as IEdible;
            int quantity = int.Parse(inputCommands[3]);

            this.farm.Feed(animal, food, quantity);
            food.Quantity -= quantity;
        }

        private void ExecuteWaterCommand(string plantId)
        {
            var plant = this.GetPlantById(plantId);
            this.farm.Water(plant);
        }
    }
}
