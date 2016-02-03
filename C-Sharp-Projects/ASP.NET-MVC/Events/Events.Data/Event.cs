namespace Events.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        private ICollection<Comment> comments;

        public Event()
        {
            this.comments = new HashSet<Comment>();
            this.StartTime = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        [Required]
        public bool IsPrivate { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}