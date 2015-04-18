namespace News.Services.IntegrationTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    public class PresharedKeyAuthorizer : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "tralala") };
            var identity = new ClaimsIdentity(claims, "PresharedKey");
            var principal = new ClaimsPrincipal(identity);

            request.GetRequestContext().Principal = principal;

            return base.SendAsync(request, cancellationToken);
        }
    }
}
