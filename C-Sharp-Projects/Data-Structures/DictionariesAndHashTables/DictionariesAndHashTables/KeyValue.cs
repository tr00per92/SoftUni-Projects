﻿namespace DictionariesAndHashTables
{
    public class KeyValue<TKey, TValue>
    {
        public KeyValue(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public override bool Equals(object other)
        {
            var element = (KeyValue<TKey, TValue>)other;
            var equals = Equals(this.Key, element.Key) && Equals(this.Value, element.Value);

            return equals;
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(this.Key.GetHashCode(), this.Value.GetHashCode());
        }

        public override string ToString()
        {
            return string.Format(" [{0} -> {1}]", this.Key, this.Value);
        }

        private static int CombineHashCodes(int h1, int h2)
        {
            return ((h1 << 5) + h1) ^ h2;
        }
    }
}