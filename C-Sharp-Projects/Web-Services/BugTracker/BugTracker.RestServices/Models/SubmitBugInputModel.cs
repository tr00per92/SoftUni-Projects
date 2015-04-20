namespace BugTracker.RestServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SubmitBugInputModel
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}