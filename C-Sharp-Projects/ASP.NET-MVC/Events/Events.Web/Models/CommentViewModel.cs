namespace Events.Web.Models
{
    using System.ComponentModel;
    using Data;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapWith<Comment>
    {
        public string Content { get; set; }

        [DisplayName("Author")]
        public string AuthorUserName { get; set; }
    }
}