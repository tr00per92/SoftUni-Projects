namespace MusicCatalog.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using MusicCatalog.Models;
    using MusicCatalog.Services.Models;

    public class SongsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.db.Songs.Select(SongDataModel.FromSong).ToList());
        }

        [HttpPost]
        public IHttpActionResult Create(SongDataModel newSong)
        {
            if (newSong == null || newSong.Title == null)
            {
                return this.BadRequest("You must provide song title.");
            }

            if (newSong.ArtistId == null || !this.db.Artists.Any(a => a.Id == newSong.ArtistId))
            {
                return this.BadRequest("Invalid artist id.");
            }

            if (newSong.AlbumId != null && !this.db.Albums.Any(a => a.Id == newSong.AlbumId))
            {
                return this.BadRequest("Invalid album id.");
            }

            var song = new Song
            {
                Title = newSong.Title,
                Genre = newSong.Genre,
                Year = newSong.Year,
                AlbumId = newSong.AlbumId,
                ArtistId = newSong.ArtistId.Value
            };

            this.db.Songs.Add(song);
            this.db.SaveChanges();

            return this.Ok(song);
        }

        [HttpPut]
        public IHttpActionResult Update(SongDataModel song)
        {
            if (song == null || song.Id == null)
            {
                return this.BadRequest("You must provide song ID.");
            }

            var existingSong = this.db.Songs.Find(song.Id);
            if (existingSong == null)
            {
                return this.BadRequest("A song with the provided ID do not exist.");
            }

            if (song.Title != null)
            {
                existingSong.Title = song.Title;
            }

            if (song.Genre != null)
            {
                existingSong.Genre = song.Genre;
            }

            if (song.Year != null)
            {
                existingSong.Year = song.Year;
            }

            if (song.ArtistId != null && this.db.Artists.Any(a => a.Id == song.ArtistId))
            {
                existingSong.ArtistId = song.ArtistId.Value;
            }

            if (song.AlbumId != null && this.db.Albums.Any(a => a.Id == song.AlbumId))
            {
                existingSong.AlbumId = song.AlbumId.Value;
            }

            this.db.SaveChanges();

            return this.Ok(existingSong);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingSong = this.db.Songs.Find(id);
            if (existingSong == null)
            {
                return this.BadRequest("A song with the provided ID do not exist.");
            }

            this.db.Songs.Remove(existingSong);
            this.db.SaveChanges();

            return this.Ok();
        }
    }
}
