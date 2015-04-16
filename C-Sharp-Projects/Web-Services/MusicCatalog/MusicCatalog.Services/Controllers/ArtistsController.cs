namespace MusicCatalog.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using MusicCatalog.Models;
    using MusicCatalog.Services.Models;

    public class ArtistsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.db.Artists
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Birthday, 
                    a.Country,
                    Songs = a.Songs.Select(s => s.Title),
                    Albums = a.Albums.Select(al => al.Title)
                })
                .ToList());
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistDataModel newArtist)
        {
            if (newArtist == null || newArtist.Name == null)
            {
                return this.BadRequest("You must provide artist name.");
            }

            var artist = new Artist
            {
                Name = newArtist.Name, 
                Country = newArtist.Country,
                Birthday = newArtist.Birthday
            };

            this.db.Artists.Add(artist);
            this.db.SaveChanges();

            return this.Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(ArtistDataModel artist)
        {
            if (artist == null || artist.Id == null)
            {
                return this.BadRequest("You must provide artist ID.");
            }

            var existingArtist = this.db.Artists.Find(artist.Id);
            if (existingArtist == null)
            {
                return this.BadRequest("An artist with the provided ID do not exist.");
            }

            if (artist.Name != null)
            {
                existingArtist.Name = artist.Name;
            }

            if (artist.Country != null)
            {
                existingArtist.Country = artist.Country;
            }

            if (artist.Birthday != null)
            {
                existingArtist.Birthday = artist.Birthday;
            }
            
            this.db.SaveChanges();

            return this.Ok(existingArtist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.db.Artists.Find(id);
            if (existingArtist == null)
            {
                return this.BadRequest("An artist with the provided ID do not exist.");
            }

            this.db.Artists.Remove(existingArtist);
            this.db.SaveChanges();

            return this.Ok();
        }
    }
}
