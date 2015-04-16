namespace MusicCatalog.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int? Year { get; set; }

        public string Genre { get; set; }

        [Required]
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
