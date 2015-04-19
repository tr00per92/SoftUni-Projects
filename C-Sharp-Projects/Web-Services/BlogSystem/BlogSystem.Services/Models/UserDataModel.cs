namespace BlogSystem.Services.Models
{
    using System;
    using BlogSystem.Models;

    public class UserDataModel
    {
        public static User ToUser(UserDataModel userDataModel)
        {
            return new User
            {
                Username = userDataModel.Username,
                FullName = userDataModel.Facebook,
                Birthday = userDataModel.Birthday,
                Gender = userDataModel.Gender,
                RegistrationDate = DateTime.Now,
                ContactInfo = new UserContactInfo
                {
                    Facebook = userDataModel.Facebook,
                    Twitter = userDataModel.Twitter,
                    Skype = userDataModel.Skype,
                    PhoneNumber = userDataModel.PhoneNumber
                }
            };
        }

        public static UserDataModel FromUser(User user)
        {
            return new UserDataModel
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                Birthday = user.Birthday,
                RegistrationDate = user.RegistrationDate,
                Gender = user.Gender,
                Facebook = user.ContactInfo.Facebook,
                Twitter = user.ContactInfo.Twitter,
                Skype = user.ContactInfo.Skype,
                PhoneNumber = user.ContactInfo.PhoneNumber
            };
        }

        public UserDataModel()
        {
            this.Gender = Gender.Other;
        }

        public int? Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public Gender Gender { get; set; }

        public string Facebook { get; set; }

        public string Skype { get; set; }

        public string Twitter { get; set; }

        public string PhoneNumber { get; set; }
    }
}