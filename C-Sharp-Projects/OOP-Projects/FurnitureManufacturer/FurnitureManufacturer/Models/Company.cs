namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;

    public class Company : ICompany
    {
        private const int MinimumNameLength = 5;
        private const int RegistrationNumberLength = 10;

        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Cannot be null or empty.");
                }

                if (value.Length < MinimumNameLength)
                {
                    throw new ArgumentOutOfRangeException("Name", "Must be at least 3 symbols.");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (value.Any(c => c > '9' || c < '0'))
                {
                    throw new ArgumentException("The registration number contain only digits");
                }

                if (value.Length != RegistrationNumberLength)
                {
                    throw new ArgumentException(string.Format(
                        "The registration number must contain exactly {0} digits", RegistrationNumberLength));
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("furniture");
            }

            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException("furniture");
            }

            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.FirstOrDefault(item =>
                string.Equals(item.Model, model, StringComparison.InvariantCultureIgnoreCase));
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0} - {1} - {2} {3}\n",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            this.furnitures.OrderBy(furniture => furniture.Price)
                .ThenBy(furniture => furniture.Model)
                .ToList()
                .ForEach(furniture => result.Append(furniture + "\n"));

            return result.ToString().Trim();
        }
    }
}
