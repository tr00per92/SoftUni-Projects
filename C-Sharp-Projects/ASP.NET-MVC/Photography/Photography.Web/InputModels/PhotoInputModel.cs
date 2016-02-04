namespace Photography.Web.InputModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Photography.Common.Mappings;
    using Photography.Models;

    public class PhotoInputModel : IMapTo<Photograph>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        public string Description { get; set; }

        [Required]
        [DisplayName("Equipment")]
        public int EquipmentId { get; set; }
    }
}