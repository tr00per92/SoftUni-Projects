namespace BugTracker.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string UserId { get; set; }

        public User Author { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public int BugId { get; set; }

        public Bug Bug { get; set; }
    }
}
