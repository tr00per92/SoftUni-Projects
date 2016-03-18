namespace DataStructuresEfficiency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private readonly MultiDictionary<K1, T> dictionary1 = new MultiDictionary<K1, T>(true);
        private readonly MultiDictionary<K2, T> dictionary2 = new MultiDictionary<K2, T>(true);
        private readonly IDictionary<Tuple<K1, K2>, T> dictionary = new Dictionary<Tuple<K1, K2>, T>();

        public T this[K1 key1, K2 key2]
        {
            get
            {
                return this.Find(key1, key2);
            }
            set
            {
                this.Add(key1, key2, value);
            }
        }

        public T Find(K1 key1, K2 key2)
        {
            var tuple = Tuple.Create(key1, key2);
            if (!this.dictionary.ContainsKey(tuple))
            {
                return default(T);
            }

            return this.dictionary[tuple];
        } 

        public IEnumerable<T> FindByKey1(K1 key)
        {
            if (!this.dictionary1.ContainsKey(key))
            {
                return Enumerable.Empty<T>();
            }

            return this.dictionary1[key];
        }

        public IEnumerable<T> FindByKey2(K2 key)
        {
            if (!this.dictionary2.ContainsKey(key))
            {
                return Enumerable.Empty<T>();
            }

            return this.dictionary2[key];
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            var pair = Tuple.Create(key1, key2);
            if (this.dictionary.ContainsKey(pair))
            {
                var existingValue = this.dictionary[pair];
                this.dictionary1.Remove(key1, existingValue);
                this.dictionary2.Remove(key2, existingValue);
            }
            
            this.dictionary[pair] = value;
            this.dictionary1.Add(key1, value);
            this.dictionary2.Add(key2, value);
        }

        public void Remove(K1 key1, K2 key2)
        {
            var pair = Tuple.Create(key1, key2);
            if (this.dictionary.ContainsKey(pair))
            {
                var existingValue = this.dictionary[pair];
                this.dictionary1.Remove(key1, existingValue);
                this.dictionary2.Remove(key2, existingValue);
                this.dictionary.Remove(pair);
            }
        }

        public bool ContainsKey(K1 key1, K2 key2)
        {
            return this.dictionary.ContainsKey(Tuple.Create(key1, key2));
        }

        public bool ContainsKey(K1 key)
        {
            return this.dictionary1.ContainsKey(key);
        }

        public bool ContainsKey(K2 key)
        {
            return this.dictionary2.ContainsKey(key);
        }

        public void Clear()
        {
            this.dictionary.Clear();
            this.dictionary1.Clear();
            this.dictionary2.Clear();
        }
    }
}
