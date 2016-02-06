namespace SportSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        public int Id { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public decimal Value { get; set; }

        public bool IsForHomeTeam { get; set; }
    }
}
