using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookmarks.Common.Mappings;
using Bookmarks.Models;

namespace Bookmarks.Web.ViewModels
{
    public class BookmarkPreviewViewModel : IMapFrom<Bookmark>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}