namespace Twitter.Web.Areas.Administration.ViewModels
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Web.Infrastructure.Mapping;

    public class RoleAdministrationViewModel : IMapFrom<IdentityRole>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
