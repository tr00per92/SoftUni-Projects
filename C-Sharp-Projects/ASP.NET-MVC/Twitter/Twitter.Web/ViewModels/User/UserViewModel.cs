namespace Twitter.Web.ViewModels.User
{
    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public bool IsCurrentUser { get; set; }

        public bool IsFollowedByCurrentUser { get; set; }
    }
}
