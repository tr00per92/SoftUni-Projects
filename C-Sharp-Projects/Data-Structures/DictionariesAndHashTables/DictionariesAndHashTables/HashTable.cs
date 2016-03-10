namespace DictionariesAndHashTables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int DefaultCapacity = 16;
        private const float LoadFactor = 0.75f;
        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public HashTable(int capacity = DefaultCapacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.slots.Length;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.Select(element => element.Key);
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.Select(element => element.Value);
            }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            return this.slots.Where(list => list != null).SelectMany(list => list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(TKey key, TValue value)
        {
            this.ExpandIfNeeded();
            var hash = this.HashKey(key);
            if (this.slots[hash] == null)
            {
                this.slots[hash] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            if (this.slots[hash].Any(x => x.Key.Equals(key)))
            {
                throw new ArgumentException("Key already exists: " + key);
            }

            this.slots[hash].AddLast(new KeyValue<TKey, TValue>(key, value));
            this.Count++;
            
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            this.ExpandIfNeeded();
            var hash = this.HashKey(key);
            if (this.slots[hash] == null)
            {
                this.slots[hash] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            var element = this.slots[hash].FirstOrDefault(x => x.Key.Equals(key));
            if (element != null)
            {
                element.Value = value;
                return false;
            }

            this.slots[hash].AddLast(new KeyValue<TKey, TValue>(key, value));
            this.Count++;
            return true;
        }

        public TValue Get(TKey key)
        {
            var element = this.Find(key);
            if (element == null)
            {
                throw new KeyNotFoundException();
            }

            return element.Value;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);
            if (element == null)
            {
                value = default(TValue);
                return false;
            }

            value = element.Value;
            return true;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            var elements = this.slots[this.HashKey(key)];
            if (elements == null)
            {
                return null;
            }

            return elements.FirstOrDefault(x => x.Key.Equals(key));
        }

        public bool ContainsKey(TKey key)
        {
            return this.Find(key) != null;
        }

        public bool Remove(TKey key)
        {
            var element = this.Find(key);
            if (element == null)
            {
                return false;
            }

            this.slots[this.HashKey(key)].Remove(element);
            this.Count--;
            return true;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
            this.Count = 0;
        }

        private int HashKey(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % this.Capacity;
        }

        private void ExpandIfNeeded()
        {
            if ((this.Count + 1) / (float)this.Capacity > LoadFactor)
            {
                this.Expand();
            }
        }

        private void Expand()
        {
            this.Count = 0;
            var oldValues = this.slots;
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[this.Capacity * 2];
            foreach (var pair in oldValues.Where(list => list != null).SelectMany(list => list))
            {
                this.Add(pair.Key, pair.Value);
            }
        }
    }
}