namespace Photography.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        private ICollection<Camera> cameras;

        private ICollection<Lense> lenses;

        public Manufacturer()
        {
            this.lenses = new HashSet<Lense>();
            this.cameras = new HashSet<Camera>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Lense> Lenses
        {
            get
            {
                return this.lenses;
            }
            set
            {
                this.lenses = value;
            }
        }

        public virtual ICollection<Camera> Cameras
        {
            get
            {
                return this.cameras;
            }
            set
            {
                this.cameras = value;
            }
        }
    }
}