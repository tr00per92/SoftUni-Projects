namespace NewsDb.Models
{
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        public int Id { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string Content { get; set; }
    }
}
