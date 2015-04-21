namespace Phonebook.Data.CodeFirst
{
    using System.ComponentModel.DataAnnotations;

    public class Email
    {
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public int ContactId { get; set; }
    }
}
