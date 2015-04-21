namespace ListPhonebookContacts
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Phonebook.Data.CodeFirst;

    public class ListPhonebookContacts
    {
        public static void Main()
        {
            using (var db = new PhonebookEntities())
            {
                foreach (var contact in db.Contacts.Include(c => c.Emails).Include(c => c.Phones))
                {
                    Console.WriteLine("Name: " + contact.Name);
                    Console.WriteLine("Emails: " + string.Join(", ", contact.Emails.Select(e => e.EmailAddress)));
                    Console.WriteLine("Phones: " + string.Join(", ", contact.Phones.Select(p => p.PhoneNumber)));
                    Console.WriteLine();
                }
            }
        }
    }
}
