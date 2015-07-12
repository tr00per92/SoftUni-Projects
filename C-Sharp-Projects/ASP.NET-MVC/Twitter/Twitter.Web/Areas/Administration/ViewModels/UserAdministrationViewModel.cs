namespace Twitter.Web.Areas.Administration.ViewModels
{
    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class UserAdministrationViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
