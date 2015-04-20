namespace BugTracker.RestServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        [Required]
        [MinLength(1)]
        public string Text { get; set; }
    }
}