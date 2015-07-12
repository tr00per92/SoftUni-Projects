namespace Bookmarks.Web.Extensions
{
    using System.Security.Principal;
    using Bookmarks.Common;
    using Microsoft.AspNet.Identity;

    public static class PrincipalExtensions
    {
        public static string GetUsername(this IPrincipal principal)
        {
            return principal.Identity.GetUserName();
        }

        public static bool IsLoggedIn(this IPrincipal principal)
        {
            return principal.Identity.IsAuthenticated;
        }

        public static bool IsAdmin(this IPrincipal principal)
        {
            return principal.IsInRole(GlobalConstants.AdminRole);
        }
    }
}
