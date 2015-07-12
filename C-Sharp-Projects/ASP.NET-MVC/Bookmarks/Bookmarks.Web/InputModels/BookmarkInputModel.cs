namespace Bookmarks.Web.InputModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Bookmarks.Common.Mappings;
    using Bookmarks.Models;

    public class BookmarkInputModel : IMapTo<Bookmark>
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        public string Description { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}