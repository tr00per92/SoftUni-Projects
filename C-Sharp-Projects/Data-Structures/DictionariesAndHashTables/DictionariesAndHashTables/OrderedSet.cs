namespace DictionariesAndHashTables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTree<T> tree;

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.tree == null)
            {
                this.tree = new BinaryTree<T>(element);
            }
            else
            {
                this.tree.AddChild(element);
            }

            this.Count++;
        }

        public void Remove(T element)
        {
            this.tree.RemoveChild(element, this.tree);
            this.Count--;
        }

        public bool Contains(T element)
        {
            return this.tree.Contains(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.tree.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
