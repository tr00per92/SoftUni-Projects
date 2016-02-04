namespace Photography.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Photograph
    {
        private ICollection<Album> albums;

        public Photograph()
        {
            this.UploadDate = DateTime.Now;
            this.albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime UploadDate { get; set; }

        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }
            set
            {
                this.albums = value;
            }
        }
    }
}