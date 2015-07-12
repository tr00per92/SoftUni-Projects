namespace Bookmarks.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;
    using Bookmarks.Common.Mappings;
    using Bookmarks.Models;

    public class CommentInputModel : IMapTo<Comment>
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public int BookmarkId { get; set; }
    }
}
