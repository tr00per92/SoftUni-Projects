using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_StringDisperser
{
    public class StringDisperser : IEnumerable<char>, IComparable<StringDisperser>, ICloneable
    {
        private readonly IList<char> characters;

        public StringDisperser(params string[] strings)
        {
            this.characters = new List<char>();
            foreach (char c in strings.SelectMany(x => x))
            {
                this.characters.Add(c);
            }
        }

        private StringDisperser(IList<char> characters)
        {
            this.characters = characters;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            this.characters.ToList().ForEach(c => result.Append(c));
            return result.ToString();
        }
        
        public override bool Equals(object obj)
        {
            StringDisperser otherDisperser = obj as StringDisperser;
            return otherDisperser != null && Equals(this.characters, otherDisperser.characters);
        }

        public override int GetHashCode()
        {
            return this.characters.GetHashCode() ^ 397;
        }

        public static bool operator ==(StringDisperser first, StringDisperser second)
        {
            return Equals(first, second);
        }

        public static bool operator !=(StringDisperser first, StringDisperser second)
        {
            return !Equals(first, second);
        }

        public int CompareTo(StringDisperser other)
        {
            return string.Compare(this.ToString(), other.ToString(), StringComparison.InvariantCulture);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<char> GetEnumerator()
        {
            return this.characters.GetEnumerator();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public StringDisperser Clone()
        {
            List<char> result = new List<char>();
            this.characters.ToList().ForEach(result.Add);
            StringDisperser cloning = new StringDisperser(result);
            return cloning;
        }
    }
}
