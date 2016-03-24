using System;
using System.ComponentModel.DataAnnotations;

namespace Geography.CodeFirst.Data
{
    public class Peak
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Elevation { get; set; }

        [Required]
        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
