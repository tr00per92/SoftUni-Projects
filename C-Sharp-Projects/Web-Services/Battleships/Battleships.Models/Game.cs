namespace Battleships.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.Id = Guid.NewGuid();
            this.State = GameState.WaitingForPlayer;
            this.PlayerOnePoints = 0;
            this.PlayerTwoPoints = 0;
            this.Field = new string('O', 64);
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(64)]
        [Column(TypeName = "char")]
        public string Field { get; set; }

        [Required]
        public GameState State { get; set; }

        [Required]
        public string PlayerOneId { get; set; }

        public virtual ApplicationUser PlayerOne { get; set; }

        [Required]
        public int PlayerOnePoints { get; set; }

        public string PlayerTwoId { get; set; }

        public virtual ApplicationUser PlayerTwo { get; set; }

        [Required]
        public int PlayerTwoPoints { get; set; }
    }
}
