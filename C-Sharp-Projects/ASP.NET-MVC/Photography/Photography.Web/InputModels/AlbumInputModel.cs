namespace Photography.Web.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Photography.Common.Mappings;
    using Photography.Models;

    public class AlbumInputModel : IMapTo<Album>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<int> PhotoIds { get; set; }
    }
}