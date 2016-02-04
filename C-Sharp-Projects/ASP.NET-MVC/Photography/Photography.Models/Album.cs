namespace Photography.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        private ICollection<Photograph> photographs;

        public Album()
        {
            this.photographs = new HashSet<Photograph>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Photograph> Photographs
        {
            get
            {
                return this.photographs;
            }
            set
            {
                this.photographs = value;
            }
        }
    }
}