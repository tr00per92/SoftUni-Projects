namespace MusicCatalog.Services.Models
{
    using System;

    public class ArtistDataModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? Birthday { get; set; }
    }
}