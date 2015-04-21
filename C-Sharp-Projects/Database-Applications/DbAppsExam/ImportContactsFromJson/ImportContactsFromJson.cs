namespace ImportContactsFromJson
{
    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;
    using Phonebook.Data.CodeFirst;

    public class ImportContactsFromJson
    {
        public static void Main()
        {
            using (var db = new PhonebookEntities())
            {
                var contacts = JArray.Parse(File.ReadAllText("../../../Helper.Files/contacts.json"));
                foreach (var contact in contacts)
                {
                    try
                    {
                        AddContact(contact, db);
                        Console.WriteLine("Contact {0} imported", contact["name"]);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                }
            }
        }

        private static void AddContact(JToken contact, PhonebookEntities db)
        {
            if (contact["name"] == null)
            {
                throw new ArgumentException("Name is required");
            }

            var newContact = new Contact { Name = contact["name"].ToString() };

            if (contact["company"] != null)
            {
                newContact.Company = contact["company"].ToString();
            }

            if (contact["position"] != null)
            {
                newContact.Position = contact["position"].ToString();
            }

            if (contact["site"] != null)
            {
                newContact.Site = contact["site"].ToString();
            }

            if (contact["notes"] != null)
            {
                newContact.Notes = contact["notes"].ToString();
            }

            if (contact["phones"] != null)
            {
                foreach (var phone in contact["phones"])
                {
                    newContact.Phones.Add(new Phone { PhoneNumber = phone.ToString() });
                }
            }

            if (contact["emails"] != null)
            {
                foreach (var email in contact["emails"])
                {
                    newContact.Emails.Add(new Email { EmailAddress = email.ToString() });
                }
            }

            db.Contacts.Add(newContact);
            db.SaveChanges();
        }
    }
}
