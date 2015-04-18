namespace News.Services.Controllers
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using News.Data;
    using News.Services.Models;

    [Authorize]
    public class UserController : ApiController
    {
        private ApplicationUserManager userManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            this.UserManager = userManager;
            this.AccessTokenFormat = accessTokenFormat;
        }
        
        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                this.userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        [Route("api/User/ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var result = await this.UserManager.ChangePasswordAsync(this.User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            
            if (!result.Succeeded)
            {
                return this.GetErrorResult(result);
            }

            return this.Ok();
        }

        [AllowAnonymous]
        [Route("api/User/Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = new User() { UserName = model.Email, Email = model.Email };

            var result = await this.UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return this.GetErrorResult(result);
            }

            return this.Ok();
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.userManager != null)
            {
                this.userManager.Dispose();
                this.userManager = null;
            }

            base.Dispose(disposing);
        }
        
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return this.InternalServerError();
            }

            if (result.Succeeded)
            {
                return null;
            }

            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError("", error);
                }
            }

            if (this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            return this.BadRequest(this.ModelState);
        }
    }
}
