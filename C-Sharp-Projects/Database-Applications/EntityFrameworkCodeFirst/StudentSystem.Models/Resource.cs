namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        public string Url { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
