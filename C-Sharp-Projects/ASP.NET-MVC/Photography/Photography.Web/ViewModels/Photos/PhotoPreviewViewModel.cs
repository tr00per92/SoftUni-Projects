namespace Photography.Web.ViewModels.Photos
{
    using System;

    using Photography.Common.Mappings;
    using Photography.Models;

    public class PhotoPreviewViewModel : IMapFrom<Photograph>
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public DateTime UploadDate { get; set; }
    }
}