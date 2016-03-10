namespace DictionariesAndHashTables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public BinaryTree(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public void AddChild(T value)
        {
            var currentNode = this;
            var nextNode = this;
            while (nextNode != null)
            {
                if (value.Equals(nextNode.Value))
                {
                    return;
                }

                currentNode = nextNode;
                nextNode = value.CompareTo(nextNode.Value) > 0 ? nextNode.RightChild : nextNode.LeftChild;
            }

            if (value.CompareTo(currentNode.Value) > 0)
            {
                currentNode.RightChild = new BinaryTree<T>(value);
            }
            else
            {
                currentNode.LeftChild = new BinaryTree<T>(value);
            }
        }

        public void RemoveChild(T value, BinaryTree<T> parent)
        {
            if (value.CompareTo(this.Value) > 0)
            {
                if (this.RightChild != null)
                {
                    this.RightChild.RemoveChild(value, this);
                }
            }
            else if (value.CompareTo(this.Value) < 0)
            {
                if (this.LeftChild != null)
                {
                    this.LeftChild.RemoveChild(value, this);
                }
            }
            else
            {
                if (this.LeftChild != null && this.RightChild != null)
                {
                    this.Value = this.RightChild.MinValue();
                    this.RightChild.RemoveChild(this.Value, this);
                }
                else if (parent.LeftChild == this)
                {
                    parent.LeftChild = this.LeftChild ?? this.RightChild;
                }
                else if (parent.RightChild == this)
                {
                    parent.RightChild = this.LeftChild ?? this.RightChild;
                }
            }
        }

        public bool Contains(T value)
        {
            var currentNode = this;
            while (currentNode != null)
            {
                if (value.Equals(currentNode.Value))
                {
                    return true;
                }

                currentNode = value.CompareTo(currentNode.Value) > 0 ? currentNode.RightChild : currentNode.LeftChild;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.LeftChild != null)
            {
                foreach (var value in this.LeftChild)
                {
                    yield return value;
                }
            }

            yield return this.Value;

            if (this.RightChild != null)
            {
                foreach (var value in this.RightChild)
                {
                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private T MinValue()
        {
            if (this.LeftChild == null)
            {
                return this.Value;
            }

            return this.LeftChild.MinValue();
        }
    }
}