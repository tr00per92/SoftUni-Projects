using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Bookmarks.Common.Mappings;
using Bookmarks.Models;

namespace Bookmarks.Web.ViewModels
{
    public class BookmarkViewModel : IMapFrom<Bookmark>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        [DisplayName("Votes")]
        public int VotesCount { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [DisplayName("User")]
        public string UserUserName { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
