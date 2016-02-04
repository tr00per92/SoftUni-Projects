namespace Photography.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Photography.Data.UnitOfWork;
    using Photography.Models;
    using Photography.Web.InputModels;
    using Photography.Web.ViewModels.Albums;

    public class AlbumsService : ServiceBase, IAlbumsService
    {
        public AlbumsService(IPhotographyData data)
            : base(data)
        {
        }

        public IEnumerable<SelectListItem> GetPhotosSelectList()
        {
            var photos = this.Data.Photographs
               .All()
               .Select(p => new SelectListItem
               {
                   Text = p.Title,
                   Value = p.Id.ToString()
               })
               .ToList();

            return photos;
        }

        public Album AddAlbum(AlbumInputModel model, string userId)
        {
            var album = Mapper.Map<Album>(model);
            album.UserId = userId;
            this.Data.Albums.Add(album);
            this.Data.SaveChanges();

            foreach (var id in model.PhotoIds.Distinct())
            {
                var photo = this.Data.Photographs.Find(id);
                if (photo != null)
                {
                    album.Photographs.Add(photo);
                }
            }

            this.Data.SaveChanges();

            return album;
        }

        public AlbumViewModel GetAlbumViewModel(int id)
        {
            var albumViewModel = this.Data.Albums
                .All()
                .Where(a => a.Id == id)
                .Project()
                .To<AlbumViewModel>()
                .FirstOrDefault();

            return albumViewModel;
        }
    }
}