namespace Photography.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Lense
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Type { get; set; }

        public decimal Price { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}