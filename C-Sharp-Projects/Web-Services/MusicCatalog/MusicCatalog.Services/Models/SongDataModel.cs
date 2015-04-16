namespace MusicCatalog.Services.Models
{
    using System;
    using System.Linq.Expressions;
    using MusicCatalog.Models;

    public class SongDataModel
    {
        public static Expression<Func<Song, SongDataModel>> FromSong
        {
            get
            {
                return song => new SongDataModel
                {
                    Id = song.Id,
                    Title = song.Title,
                    Genre = song.Genre,
                    ArtistId = song.ArtistId,
                    AlbumId = song.AlbumId,
                    Year = song.Year
                };
            }
        }

        public int? Id { get; set; }

        public string Title { get; set; }

        public int? Year { get; set; }

        public string Genre { get; set; }

        public int? ArtistId { get; set; }

        public int? AlbumId { get; set; }
    }
}