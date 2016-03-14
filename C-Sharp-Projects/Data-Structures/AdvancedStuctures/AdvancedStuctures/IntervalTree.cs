namespace AdvancedStuctures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntervalTree<T> where T : IComparable<T>
    {
        private HashSet<Interval<T>> intervals = new HashSet<Interval<T>>();
        private Node root = new Node();

        public IntervalTree()
        {
            this.IsInSync = true;
            this.AutoRebuild = true;
        }

        public bool IsInSync { get; private set; }

        public bool AutoRebuild { get; set; }

        public int Count
        {
            get { return this.intervals.Count; }
        }

        public IEnumerable<Interval<T>> GetOverlaps(T value)
        {
            CheckForNull(value, "value");
            this.RebuildIfNeeded();
            return this.root.GetOverlaps(value);
        }

        public IEnumerable<Interval<T>> GetOverlaps(T min, T max)
        {
            return this.GetOverlaps(new Interval<T>(min, max));
        }

        public IEnumerable<Interval<T>> GetOverlaps(Interval<T> interval)
        {
            CheckForNull(interval, "interval");
            this.RebuildIfNeeded();
            return this.root.GetOverlaps(interval);
        }

        public void Rebuild()
        {
            if (!this.IsInSync)
            {
                this.root = new Node(this.intervals);
                this.IsInSync = true;
            }
        }

        public void Add(T min, T max)
        {
            this.Add(new Interval<T>(min, max));
        }

        public void Add(Interval<T> interval)
        {
            CheckForNull(interval, "interval");
            this.IsInSync = false;
            this.intervals.Add(interval);
        }

        public void AddRange(IEnumerable<Interval<T>> items)
        {
            CheckForNull(items, "items");
            this.IsInSync = false;
            foreach (var interval in items)
            {
                this.intervals.Add(interval);
            }
        }

        public void Remove(T min, T max)
        {
            this.Remove(new Interval<T>(min, max));
        }

        public void Remove(Interval<T> item)
        {
            CheckForNull(item, "item");
            this.IsInSync = false;
            this.intervals.Remove(item);
        }

        public void RemoveRange(IEnumerable<Interval<T>> items)
        {
            CheckForNull(items, "items");
            this.IsInSync = false;
            foreach (var interval in items)
            {
                this.intervals.Remove(interval);
            }
        }

        public void Clear()
        {
            this.root = new Node();
            this.intervals = new HashSet<Interval<T>>();
            this.IsInSync = true;
        }

        private void RebuildIfNeeded()
        {
            if (this.AutoRebuild)
            {
                this.Rebuild();
            }
        }

        private static void CheckForNull(object item, string variableName)
        {
            if (item == null)
            {
                throw new ArgumentNullException(variableName);
            }
        }

        private class Node
        {
            private readonly T center;
            private readonly SortedSet<Interval<T>> intervals = new SortedSet<Interval<T>>();
            private readonly Node leftChild;
            private readonly Node rightChild;

            public Node()
            {
            }

            public Node(ICollection<Interval<T>> intervals)
            {
                var allPoints = new List<T>();
                foreach (var interval in intervals)
                {
                    allPoints.Add(interval.Min);
                    allPoints.Add(interval.Max);
                }

                allPoints.Sort();
                this.center = allPoints[allPoints.Count / 2];

                var leftIntervals = new List<Interval<T>>();
                var rightIntervals = new List<Interval<T>>();
                foreach (var item in intervals)
                {
                    if (item.Max.CompareTo(this.center) < 0)
                    {
                        leftIntervals.Add(item);
                    }
                    else if (item.Min.CompareTo(this.center) > 0)
                    {
                        rightIntervals.Add(item);
                    }
                    else
                    {
                        this.intervals.Add(item);
                    }
                }

                if (leftIntervals.Any())
                {
                    this.leftChild = new Node(leftIntervals);
                }

                if (rightIntervals.Any())
                {
                    this.rightChild = new Node(rightIntervals);
                }
            }

            public IEnumerable<Interval<T>> GetOverlaps(T value)
            {
                var results = new List<Interval<T>>();
                foreach (var interval in this.intervals)
                {
                    if (interval.Min.CompareTo(value) > 0)
                    {
                        break;
                    }

                    if (interval.Contains(value))
                    {
                        results.Add(interval);
                    }
                }

                // go to the left or go to the right, depending on where the value lies compared to the center
                if (value.CompareTo(this.center) < 0)
                {
                    if (this.leftChild != null)
                    {
                        results.AddRange(this.leftChild.GetOverlaps(value));
                    }
                }
                else if (value.CompareTo(this.center) > 0)
                {
                    if (this.rightChild != null)
                    {
                        results.AddRange(this.rightChild.GetOverlaps(value));
                    }
                }

                return results;
            }

            public IEnumerable<Interval<T>> GetOverlaps(Interval<T> interval)
            {
                var results = new List<Interval<T>>();
                foreach (var item in this.intervals)
                {
                    if (item.Min.CompareTo(interval.Max) > 0)
                    {
                        break;
                    }

                    if (item.Overlaps(interval))
                    {
                        results.Add(item);
                    }
                }

                // go to the left or go to the right, depending on where the value lies compared to the center
                if (interval.Min.CompareTo(this.center) < 0)
                {
                    if (this.leftChild != null)
                    {
                        results.AddRange(this.leftChild.GetOverlaps(interval));
                    }
                }
                else if (interval.Max.CompareTo(this.center) > 0)
                {
                    if (this.rightChild != null)
                    {
                        results.AddRange(this.rightChild.GetOverlaps(interval));
                    }
                }

                return results;
            }
        }
    }
}