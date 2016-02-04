namespace Photography.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Camera
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Megapixels { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}