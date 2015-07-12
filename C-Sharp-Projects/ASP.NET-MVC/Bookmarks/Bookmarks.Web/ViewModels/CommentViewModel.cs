namespace Bookmarks.Web.ViewModels
{
    using Bookmarks.Common.Mappings;
    using Bookmarks.Models;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Text { get; set; }

        public string UserUserName { get; set; }
    }
}
