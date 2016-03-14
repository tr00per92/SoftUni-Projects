namespace AdvancedStuctures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class AaTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private static readonly Node sentinel = new Node();
        private Node deletedNode;
        private Node rootNode = sentinel;

        public IEnumerator<T> GetEnumerator()
        {
            if (this.rootNode != sentinel)
            {
                return this.rootNode.GetEnumerator();
            }

            return new List<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T value)
        {
            CheckForNull(value, "value");
            this.Insert(ref this.rootNode, value);
        }

        public void Remove(T value)
        {
            CheckForNull(value, "value");
            this.Delete(ref this.rootNode, value);
        }

        public bool Contains(T value)
        {
            CheckForNull(value, "value");
            var currentNode = this.rootNode;
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

        private static void Skew(ref Node node)
        {
            if (node.Level == node.LeftChild.Level)
            {
                var left = node.LeftChild;
                node.LeftChild = left.RightChild;
                left.RightChild = node;
                node = left;
            }
        }

        private static void Split(ref Node node)
        {
            if (node.RightChild.RightChild.Level == node.Level)
            {
                var right = node.RightChild;
                node.RightChild = right.LeftChild;
                right.LeftChild = node;
                node = right;
                node.Level++;
            }
        }

        private void Insert(ref Node node, T value)
        {
            if (node == sentinel)
            {
                node = new Node(value, sentinel);
                return;
            }

            if (value.Equals(node.Value))
            {
                throw new ArgumentException("This item already exists.");
            }

            if (value.CompareTo(node.Value) < 0)
            {
                this.Insert(ref node.LeftChild, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                this.Insert(ref node.RightChild, value);
            }

            Skew(ref node);
            Split(ref node);
        }

        private void Delete(ref Node node, T value)
        {
            if (node == sentinel)
            {
                return;
            }

            if (value.CompareTo(node.Value) < 0)
            {
                this.Delete(ref node.LeftChild, value);
            }
            else
            {
                if (value.Equals(node.Value))
                {
                    this.deletedNode = node;
                }

                this.Delete(ref node.RightChild, value);
            }

            if (this.deletedNode != null)
            {
                this.deletedNode.Value = node.Value;
                this.deletedNode = null;
                node = node.RightChild;
            }
            else if (node.LeftChild.Level < node.Level - 1 || node.RightChild.Level < node.Level - 1)
            {
                if (node.RightChild.Level > --node.Level)
                {
                    node.RightChild.Level = node.Level;
                }

                Skew(ref node);
                Skew(ref node.RightChild);
                Skew(ref node.RightChild.RightChild);
                Split(ref node);
                Split(ref node.RightChild);
            }
        }

        private static void CheckForNull(object item, string variableName)
        {
            if (item == null)
            {
                throw new ArgumentNullException(variableName);
            }
        }

        private class Node : IEnumerable<T>
        {
            internal Node LeftChild;
            internal Node RightChild;

            public Node()
            {
                this.Level = 0;
                this.LeftChild = this;
                this.RightChild = this;
            }

            public Node(T value, Node sentinel)
            {
                this.Level = 1;
                this.LeftChild = sentinel;
                this.RightChild = sentinel;
                this.Value = value;
            }

            public T Value { get; set; }

            public int Level { get; set; }

            public IEnumerator<T> GetEnumerator()
            {
                if (this.Level <= 0)
                {
                    yield break;
                }

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
        }
    }
}