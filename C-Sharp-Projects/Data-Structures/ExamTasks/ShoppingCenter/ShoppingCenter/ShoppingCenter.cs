namespace ShoppingCenter
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ShoppingCenter
    {
        private readonly MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);

        private readonly MultiDictionary<string, Product> productsByNameAndProducer =
            new MultiDictionary<string, Product>(true);

        private readonly OrderedMultiDictionary<decimal, Product> productsByPrice =
            new OrderedMultiDictionary<decimal, Product>(true);

        private readonly MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);

        public string ProcessCommand(string cmd)
        {
            var tokens = cmd.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            var parameters = tokens[1].Split(';');
            switch (tokens[0])
            {
                case "AddProduct":
                    return this.AddProduct(parameters[0], decimal.Parse(parameters[1]), parameters[2]);
                case "DeleteProducts":
                    if (parameters.Length == 1)
                    {
                        return this.DeleteProduct(parameters[0]);
                    }

                    return this.DeleteProduct(parameters[0], parameters[1]);
                case "FindProductsByName":
                    return this.FindByName(parameters[0]);
                case "FindProductsByProducer":
                    return this.FindByProducer(parameters[0]);
                case "FindProductsByPriceRange":
                    return this.FindByPriceRange(decimal.Parse(parameters[0]), decimal.Parse(parameters[1]));
                default:
                    throw new InvalidOperationException();
            }
        }

        private string AddProduct(string name, decimal price, string producer)
        {
            var product = new Product { Name = name, Price = price, Producer = producer };
            this.productsByName[name].Add(product);
            this.productsByProducer[producer].Add(product);
            this.productsByNameAndProducer[name + producer].Add(product);
            this.productsByPrice[price].Add(product);

            return "Product added";
        }

        private string DeleteProduct(string producer)
        {
            var products = this.productsByProducer[producer];
            var count = products.Count;
            if (count == 0)
            {
                return "No products found";
            }

            foreach (var product in products)
            {
                this.productsByName.Remove(product.Name, product);
                this.productsByNameAndProducer.Remove(product.Name + product.Producer, product);
                this.productsByPrice.Remove(product.Price, product);
            }

            this.productsByProducer.Remove(producer);

            return string.Format("{0} products deleted", count);
        }

        private string DeleteProduct(string name, string producer)
        {
            var products = this.productsByNameAndProducer[name + producer];
            if (!products.Any())
            {
                return "No products found";
            }

            foreach (var product in products)
            {
                this.productsByName.Remove(product.Name, product);
                this.productsByProducer.Remove(product.Producer, product);
                this.productsByPrice.Remove(product.Price, product);
            }

            var count = products.Count;
            this.productsByNameAndProducer.Remove(name + producer);

            return string.Format("{0} products deleted", count);
        }

        private string FindByName(string name)
        {
            var products = this.productsByName[name];
            if (!products.Any())
            {
                return "No products found";
            }

            return string.Join(Environment.NewLine, products.OrderBy(p => p));
        }

        private string FindByProducer(string producer)
        {
            var products = this.productsByProducer[producer];
            if (products.Count == 0)
            {
                return "No products found";
            }

            return string.Join(Environment.NewLine, products.OrderBy(p => p));
        }

        private string FindByPriceRange(decimal min, decimal max)
        {
            var products = this.productsByPrice.Range(min, true, max, true).Values;
            if (products.Count == 0)
            {
                return "No products found";
            }

            return string.Join(Environment.NewLine, products.OrderBy(p => p));
        }
    }
}