namespace BlogSystem.Services.Controllers
{
    using System.Web.Http;
    using BlogSystem.Services.Models;

    public class UsersController : BaseController
    {
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var user = this.data.Users.GetById(id);
            if (user == null)
            {
                return this.BadRequest("Unexisting user.");
            }

            return this.Ok(UserDataModel.FromUser(user));
        }

        [HttpPost]
        public IHttpActionResult Register(UserDataModel user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Username))
            {
                return this.BadRequest("The username is required.");
            }

            this.data.Users.Add(UserDataModel.ToUser(user));
            this.data.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(UserDataModel user)
        {
            if (user == null || user.Id == null)
            {
                return this.BadRequest("The user id is required.");
            }

            var existingUser = this.data.Users.GetById(user.Id);
            if (existingUser == null)
            {
                return this.BadRequest("A user with the provided id do not exist.");
            }

            existingUser.Gender = user.Gender;
            existingUser.Username = user.Username;
            existingUser.FullName = user.FullName;
            existingUser.Birthday = user.Birthday;
            existingUser.ContactInfo.Facebook = user.Facebook;
            existingUser.ContactInfo.Skype = user.Skype;
            existingUser.ContactInfo.Twitter = user.Twitter;
            existingUser.ContactInfo.PhoneNumber = user.PhoneNumber;

            this.data.SaveChanges();

            return this.Ok();
        }
    }
}