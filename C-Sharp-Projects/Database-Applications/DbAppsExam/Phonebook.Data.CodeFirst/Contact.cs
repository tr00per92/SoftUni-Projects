﻿namespace Phonebook.Data.CodeFirst
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        private ICollection<Phone> phones;
        private ICollection<Email> emails;

        public Contact()
        {
            this.phones = new HashSet<Phone>();
            this.emails = new HashSet<Email>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Site { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<Phone> Phones
        {
            get
            {
                return this.phones;
            }
            set
            {
                this.phones = value;
            }
        }

        public virtual ICollection<Email> Emails
        {
            get
            {
                return this.emails;
            }
            set
            {
                this.emails = value;
            }
        }
    }
}
