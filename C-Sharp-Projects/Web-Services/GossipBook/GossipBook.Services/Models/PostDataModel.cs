namespace GossipBook.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PostDataModel
    {
        [Required]
        public string Content { get; set; }
    }
}