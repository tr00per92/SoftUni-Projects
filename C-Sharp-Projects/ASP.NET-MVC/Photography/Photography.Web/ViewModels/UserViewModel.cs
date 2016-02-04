namespace Photography.Web.ViewModels
{
    using System.Collections.Generic;

    using Photography.Common.Mappings;
    using Photography.Models;
    using Photography.Web.ViewModels.Albums;
    using Photography.Web.ViewModels.Photos;

    public class UserViewModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<AlbumPreviewViewModel> Albums { get; set; }

        public ICollection<PhotoPreviewViewModel> Photographs { get; set; }

        public EquipmentViewModel Equipment { get; set; }
    }
}