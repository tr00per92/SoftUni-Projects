namespace Phonebook.Data.CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhonebookEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhonebookEntities db)
        {
            if (db.Phones.Any() || db.Emails.Any() || db.Contacts.Any())
            {
                return;
            }

            db.Contacts.Add(new Contact
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Company = "Smart Ideas",
                Emails =  new[]
                {
                    new Email { EmailAddress = "peter@gmail.com"},
                    new Email { EmailAddress = "peter_ivanov@yahoo.com"}
                },
                Phones = new[]
                {
                    new Phone { PhoneNumber = "+359 2 22 22 22" }, 
                    new Phone { PhoneNumber = "+359 88 77 88 99" }
                },
                Site = "http://blog.peter.com",
                Notes = "Friend from school"
            });

            db.Contacts.Add(new Contact
            {
                Name = "Maria",
                Phones = new[] { new Phone { PhoneNumber = "+359 22 33 44 55" } }
            });

            db.Contacts.Add(new Contact
            {
                Name = "Angie Stanton",
                Emails = new[] { new Email { EmailAddress = "info@angiestanton.com" } },
                Site = "http://angiestanton.com"
            });
        }
    }
}
