namespace Collection_of_Persons
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PersonCollection : IPersonCollection
    {
        private readonly OrderedDictionary<int, SortedSet<Person>> peopleByAge =
            new OrderedDictionary<int, SortedSet<Person>>();

        private readonly IDictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByAgeAndTown =
            new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

        private readonly IDictionary<string, SortedSet<Person>> peopleByDomain =
            new Dictionary<string, SortedSet<Person>>();

        private readonly IDictionary<string, Person> peopleByEmail = new Dictionary<string, Person>();

        private readonly IDictionary<string, SortedSet<Person>> peopleByNameAndTown =
            new Dictionary<string, SortedSet<Person>>();

        public int Count
        {
            get { return this.peopleByEmail.Count; }
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.peopleByEmail.ContainsKey(email))
            {
                return false;
            }

            var person = new Person { Age = age, Name = name, Email = email, Town = town };
            this.peopleByEmail[email] = person;
            this.peopleByAge.AppendValueToKey(age, person);
            this.peopleByNameAndTown.AppendValueToKey(name + town, person);
            this.peopleByDomain.AppendValueToKey(email.Split('@')[1], person);
            this.peopleByAgeAndTown.EnsureKeyExists(town);
            this.peopleByAgeAndTown[town].AppendValueToKey(age, person);

            return true;
        }

        public Person FindPerson(string email)
        {
            Person person;
            this.peopleByEmail.TryGetValue(email, out person);

            return person;
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            if (person == null)
            {
                return false;
            }

            this.peopleByEmail.Remove(email);
            this.peopleByDomain[email.Split('@')[1]].Remove(person);
            this.peopleByNameAndTown[person.Name + person.Town].Remove(person);
            this.peopleByAge[person.Age].Remove(person);
            this.peopleByAgeAndTown[person.Town][person.Age].Remove(person);

            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.peopleByDomain.GetValuesForKey(emailDomain);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return this.peopleByNameAndTown.GetValuesForKey(name + town);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            return this.peopleByAge.Range(startAge, true, endAge, true).Values.SelectMany(x => x);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            if (!this.peopleByAgeAndTown.ContainsKey(town))
            {
                return Enumerable.Empty<Person>();
            }

            return this.peopleByAgeAndTown[town].Range(startAge, true, endAge, true).Values.SelectMany(x => x);
        }
    }
}