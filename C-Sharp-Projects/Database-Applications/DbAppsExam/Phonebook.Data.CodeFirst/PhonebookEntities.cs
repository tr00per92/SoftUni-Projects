namespace Phonebook.Data.CodeFirst
{
    using System.Data.Entity;
    using Phonebook.Data.CodeFirst.Migrations;

    public class PhonebookEntities : DbContext
    {
        public PhonebookEntities()
            : base("PhonebookConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookEntities, Configuration>());
        }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}