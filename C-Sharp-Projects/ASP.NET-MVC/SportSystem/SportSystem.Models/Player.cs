namespace SportSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Height { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
