namespace Photography.Web.InputModels
{
    using Photography.Common.Mappings;
    using Photography.Models;

    public class EquipmentInputModel : IMapTo<Equipment>
    {
        public int CameraId { get; set; }

        public int LenseId { get; set; }
    }
}