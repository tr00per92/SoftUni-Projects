namespace Photography.Web.ViewModels
{
    using System.Collections.Generic;

    using Photography.Web.ViewModels.Albums;
    using Photography.Web.ViewModels.Photos;

    public class HomePageViewModel
    {
        public IEnumerable<AlbumPreviewViewModel> LatestAlbums { get; set; }

        public IEnumerable<PhotoPreviewViewModel> LatestPhotos { get; set; }
    }
}