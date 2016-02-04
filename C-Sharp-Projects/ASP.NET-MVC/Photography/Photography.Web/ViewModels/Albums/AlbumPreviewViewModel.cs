namespace Photography.Web.ViewModels.Albums
{
    using Photography.Common.Mappings;
    using Photography.Models;

    public class AlbumPreviewViewModel : IMapFrom<Album>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}