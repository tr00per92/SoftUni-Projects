namespace DataStructuresEfficiency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ProductsCollection
    {
        private readonly IDictionary<int, Product> productsById = new Dictionary<int, Product>();
        private readonly OrderedMultiDictionary<decimal, Product> productsByPrice = new OrderedMultiDictionary<decimal, Product>(false);
        private readonly MultiDictionary<string, Product> productsByTitle = new MultiDictionary<string, Product>(false);
        private readonly IDictionary<string, OrderedMultiDictionary<decimal, Product>> productsByTitleAndPrice = new Dictionary<string, OrderedMultiDictionary<decimal, Product>>();
        private readonly IDictionary<string, OrderedMultiDictionary<decimal, Product>> productsBySupplierAndPrice = new Dictionary<string, OrderedMultiDictionary<decimal, Product>>(); 

        public Product FindById(int productId)
        {
            if (!this.Contains(productId))
            {
                return null;
            }

            return this.productsById[productId];
        }

        public IEnumerable<Product> FindByPrice(decimal price)
        {
            return this.productsByPrice[price];
        } 

        public IEnumerable<Product> FindByPriceRange(decimal from, decimal to)
        {
            return this.productsByPrice.Range(from, true, to, true).Values;
        }

        public IEnumerable<Product> FindByTitle(string title)
        {
            return this.productsByTitle[title];
        }

        public IEnumerable<Product> FindByPriceAndTitle(decimal price, string title)
        {
            if (!this.productsByTitleAndPrice.ContainsKey(title))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitleAndPrice[title][price];
        }

        public IEnumerable<Product> FindByPriceRangeAndTitle(decimal from, decimal to, string title)
        {
            if (!this.productsByTitleAndPrice.ContainsKey(title))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitleAndPrice[title].Range(from, true, to, true).Values;
        }

        public IEnumerable<Product> FindByPriceAndSupplier(decimal price, string supplier)
        {
            if (!this.productsBySupplierAndPrice.ContainsKey(supplier))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitleAndPrice[supplier][price];
        }

        public IEnumerable<Product> FindByPriceRangeAndSupplier(decimal from, decimal to, string supplier)
        {
            if (!this.productsBySupplierAndPrice.ContainsKey(supplier))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitleAndPrice[supplier].Range(from, true, to, true).Values;
        } 

        public void Add(Product product)
        {
            if (product == null || product.Id <= 0)
            {
                throw new NullReferenceException("product");
            }

            if (this.productsById.ContainsKey(product.Id))
            {
                throw new InvalidOperationException("This product already exists.");
            }

            this.productsById[product.Id] = product;

            if (!string.IsNullOrWhiteSpace(product.Title))
            {
                this.productsByTitle[product.Title].Add(product);
            }

            if (product.Price <= 0)
            {
                return;
            }

            this.productsByPrice[product.Price].Add(product);

            if (!string.IsNullOrWhiteSpace(product.Title))
            {
                OrderedMultiDictionary<decimal, Product> byPrice;
                if (this.productsByTitleAndPrice.ContainsKey(product.Title))
                {
                    byPrice = this.productsByTitleAndPrice[product.Title];
                }
                else
                {
                    byPrice = new OrderedMultiDictionary<decimal, Product>(false);
                    this.productsByTitleAndPrice[product.Title] = byPrice;
                }

                byPrice[product.Price].Add(product);
            }

            if (!string.IsNullOrWhiteSpace(product.Supplier))
            {
                OrderedMultiDictionary<decimal, Product> bySupplier;
                if (this.productsBySupplierAndPrice.ContainsKey(product.Supplier))
                {
                    bySupplier = this.productsBySupplierAndPrice[product.Supplier];
                }
                else
                {
                    bySupplier = new OrderedMultiDictionary<decimal, Product>(false);
                    this.productsBySupplierAndPrice[product.Supplier] = bySupplier;
                }

                bySupplier[product.Price].Add(product);
            }
        }

        public void Remove(int productId)
        {
            if (!this.Contains(productId))
            {
                return;
            }

            var product = this.productsById[productId];
            this.productsById.Remove(productId);
            this.productsByPrice.Remove(product.Price, product);
            this.productsByTitle.Remove(product.Title, product);

            this.productsByTitleAndPrice[product.Title].Remove(product.Price, product);
            if (!this.productsByTitleAndPrice[product.Title].Any())
            {
                this.productsByTitleAndPrice.Remove(product.Title);
            }

            this.productsBySupplierAndPrice[product.Supplier].Remove(product.Price, product);
            if (!this.productsBySupplierAndPrice[product.Supplier].Any())
            {
                this.productsBySupplierAndPrice.Remove(product.Supplier);
            }
        }

        public bool Contains(int productId)
        {
            return this.productsById.ContainsKey(productId);
        }

        public bool Contains(Product product)
        {
            return this.Contains(product.Id);
        }

        public void Clear()
        {
            this.productsById.Clear();
            this.productsByPrice.Clear();
            this.productsByTitle.Clear();
            this.productsByTitleAndPrice.Clear();
            this.productsBySupplierAndPrice.Clear();
        }
    }
}
