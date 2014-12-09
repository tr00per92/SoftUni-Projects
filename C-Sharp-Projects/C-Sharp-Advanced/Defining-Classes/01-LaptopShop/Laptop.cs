using System;

namespace _01_LaptopShop
{
    class Laptop
    {
        private string model;
        private decimal price;

        public Laptop(string model, string manufacturer, string processor, string ram,
            string graphicsCard, string hdd, Battery battery, string screen, decimal price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Battery = battery;
            this.Screen = screen;
            this.Price = price;
        }
        public Laptop(string model, decimal price)
            : this(model, null, null, null, null, null, new Battery(), null, price) { }


        public string Model
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid model name");
                }
                this.model = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.price = value;
            }
        }
        public string Manufacturer { get; set; }
        public string Processor { get; set; }
        public string Ram { get; set; }
        public string GraphicsCard { get; set; }
        public string Hdd { get; set; }
        public Battery Battery { get; set; }
        public string Screen { get; set; }

        public override string ToString()
        {
            return String.Format("Model: {0}\nManufacturer: {1}\nProcessor: {2}\nRam: {3}\nGraphics Card: {4}\nHDD: {5}\nBattery: {6}\nScreen Size: {7}\nPrice: {8:F2} lv.",
                this.Model, this.Manufacturer ?? "Not specified", this.Processor ?? "Not specified", this.Ram ?? "Not specified",
                this.GraphicsCard ?? "Not specified", this.Hdd ?? "Not specified", this.Battery, this.Screen ?? "Not specified", this.Price);
        }
    }
}
