namespace MVC_AJAX.Data
{
    using System.Collections.Generic;
    using MVC_AJAX.Models;

    public class PeopleData
    {
        public IEnumerable<PersonViewModel> All()
        {
            return new HashSet<PersonViewModel>
            {
                new PersonViewModel
                {
                    Id = 10,
                    Name = "Bill Gates",
                    Age = 60,
                    Email = "gates@microsoft.com",
                    PhoneNumber = "46465898656",
                    ImageLink = "https://pbs.twimg.com/profile_images/558109954561679360/j1f9DiJi_reasonably_small.jpeg"
                },
                new PersonViewModel
                {
                    Id = 20,
                    Name = "Marc Zuckerberg",
                    Age = 30,
                    Email = "mark@facebook.com",
                    PhoneNumber = "88867564456",
                    ImageLink = "http://i.guim.co.uk/static/w-620/h--/q-95/sys-images/Media/Pix/pictures/2007/07/23/MarkZuckerberg128.jpg"
                },
                new PersonViewModel
                {
                    Id = 30,
                    Name = "Petur Petrov",
                    Age = 25,
                    Email = "pesho@gosho.com",
                    PhoneNumber = "0888888888",
                    ImageLink = "https://cdn.evbuc.com/images/7216337/3347598296/1/logo.jpg"
                },
                new PersonViewModel
                {
                    Id = 40,
                    Name = "Gosho Goshev",
                    Age = 60,
                    Email = "gosho@pesho.com",
                    PhoneNumber = "09999999",
                    ImageLink = "http://webbiquity.com/wp-content/uploads/2011/12/Bryan-Person2.jpg"
                }
            };
        }  
    }
}
