namespace MusicCatalog.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using MusicCatalog.Models;
    using MusicCatalog.Services.Models;

    public class AlbumsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.db.Albums
                .Select(a => new
                {
                    a.Id,
                    a.Title, 
                    a.Producer,
                    a.Year,
                    Songs = a.Songs.Select(s => s.Title),
                    Artists = a.Artists.Select(ar => ar.Name)
                })
                .ToList());
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumDataModel newAlbum)
        {
            if (newAlbum == null || newAlbum.Title == null)
            {
                return this.BadRequest("You must proive album title.");
            }

            var album = new Album
            {
                Title = newAlbum.Title,
                Producer = newAlbum.Producer,
                Year = newAlbum.Year
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();

            return this.Ok(album);
        }

        [HttpPut]
        public IHttpActionResult Update(AlbumDataModel album)
        {
            if (album == null || album.Id == null)
            {
                return this.BadRequest("You must provide album ID.");
            }

            var existingAlbum = this.db.Albums.Find(album.Id);
            if (existingAlbum == null)
            {
                return this.BadRequest("An album with the provided ID do not exist.");
            }

            if (album.Title != null)
            {
                existingAlbum.Title = album.Title;
            }

            if (album.Producer != null)
            {
                existingAlbum.Producer = album.Producer;
            }

            if (album.Year != null)
            {
                existingAlbum.Year = album.Year;
            }

            this.db.SaveChanges();

            return this.Ok(existingAlbum);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAlbum = this.db.Albums.Find(id);
            if (existingAlbum == null)
            {
                return this.BadRequest("An album with the provided ID do not exist.");
            }

            this.db.Albums.Remove(existingAlbum);
            this.db.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult AddSong(int albumId, int songId)
        {
            var album = this.db.Albums.Find(albumId);
            var song = this.db.Songs.Find(songId);
            if (album == null || song == null)
            {
                return this.BadRequest("Unexisting song or album");
            }

            album.Songs.Add(song);
            this.db.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult AddArtist(int albumId, int artistId)
        {
            var album = this.db.Albums.Find(albumId);
            var artist = this.db.Artists.Find(artistId);
            if (album == null || artist == null)
            {
                return this.BadRequest("Unexisting artist or album");
            }

            album.Artists.Add(artist);
            this.db.SaveChanges();

            return this.Ok();
        }
    }
}
