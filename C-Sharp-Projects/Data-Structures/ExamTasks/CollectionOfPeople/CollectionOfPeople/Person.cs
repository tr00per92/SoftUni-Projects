namespace Collection_of_Persons
{
    using System;

    public class Person : IComparable<Person>
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (other == null)
            {
                return 1;
            }

            return string.Compare(this.Email, other.Email, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}