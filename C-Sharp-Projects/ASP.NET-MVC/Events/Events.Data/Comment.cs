namespace Events.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}