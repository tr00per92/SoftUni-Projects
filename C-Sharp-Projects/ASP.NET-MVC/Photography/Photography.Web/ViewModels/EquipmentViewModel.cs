namespace Photography.Web.ViewModels
{
    using Photography.Common.Mappings;
    using Photography.Models;

    public class EquipmentViewModel : IMapFrom<Equipment>
    {
        public string CameraModel { get; set; }

        public string LenseModel { get; set; }
    }
}