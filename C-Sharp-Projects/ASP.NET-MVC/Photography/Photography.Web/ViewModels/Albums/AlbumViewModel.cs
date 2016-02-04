namespace Photography.Web.ViewModels.Albums
{
    using System.Collections.Generic;

    using Photography.Common.Mappings;
    using Photography.Models;
    using Photography.Web.ViewModels.Photos;

    public class AlbumViewModel : IMapFrom<Album>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string UserEmail { get; set; }

        public ICollection<PhotoViewModel> Photographs { get; set; }
    }
}