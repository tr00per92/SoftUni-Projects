namespace News.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        public News()
        {
            this.PublishDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public string UserId { get; set; }
    }
}
