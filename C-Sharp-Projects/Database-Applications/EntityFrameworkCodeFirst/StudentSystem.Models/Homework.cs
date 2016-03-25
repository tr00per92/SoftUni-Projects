namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        // string for test purposes, better binary
        public string Content { get; set; }

        public ContentType? ContentType { get; set; }

        [Required]
        public DateTime TimeSent { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
