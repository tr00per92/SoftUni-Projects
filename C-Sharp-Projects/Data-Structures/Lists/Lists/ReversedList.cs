namespace LinearDataStructurestLists
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 8;

        private T[] elements;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.elements.Length; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.elements[this.Count - 1 - index];
            }
        }

        public void Add(T element)
        {
            if (this.Count >= this.Capacity)
            {
                this.Expand();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (var i = index; i < this.Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            
            this.elements[Count] = default(T);
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Expand()
        {
            var expandedArray = new T[this.Capacity * 2];
            Array.Copy(this.elements, expandedArray, this.Capacity);
            this.elements = expandedArray;
        }
    }
}
