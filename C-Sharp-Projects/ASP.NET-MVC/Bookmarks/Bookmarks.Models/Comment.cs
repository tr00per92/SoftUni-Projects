namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
