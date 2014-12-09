using System;

namespace _00_Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }
        public Person(string name, int age)
            : this(name, age, null) { }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1 || age > value)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.age = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (value != null && !value.Contains("@"))
                {
                    throw new ArgumentException("The email must contain @");
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}, Email: {2}", this.Name, this.Age, this.Email ?? "not entered");
        }
    }
}
