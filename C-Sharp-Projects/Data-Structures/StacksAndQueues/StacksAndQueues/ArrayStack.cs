namespace StacksAndQueues
{
    using System;

    public class ArrayStack<T>
    {
        private const int DefaultCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            this.Count--;

            return this.elements[this.Count];
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = this.elements[this.Count - i - 1];
            }

            return result;
        }

        private void Grow()
        {
            var newelements = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newelements, this.Count);
            this.elements = newelements;
        }
    }
}
