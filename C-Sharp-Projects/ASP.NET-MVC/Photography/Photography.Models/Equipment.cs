namespace Photography.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public int CameraId { get; set; }

        public virtual Camera Camera { get; set; }

        public int LenseId { get; set; }

        public virtual Lense Lense { get; set; }
    }
}