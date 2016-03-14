namespace AdvancedStuctures
{
    using System;

    public class Interval<T> : IComparable<Interval<T>>, IEquatable<Interval<T>> where T : IComparable<T>
    {
        public Interval(T min, T max)
        {
            if (min == null || max == null)
            {
                throw new ArgumentException("The min and max values are required.");
            }

            if (min.CompareTo(max) >= 0)
            {
                throw new ArgumentException("The min value must be less than the max value.");
            }

            this.Min = min;
            this.Max = max;
        }

        public T Min { get; private set; }

        public T Max { get; private set; }

        public int CompareTo(Interval<T> other)
        {
            if (other == null)
            {
                return 1;
            }

            var minCompare = this.Min.CompareTo(other.Min);
            if (minCompare != 0)
            {
                return minCompare;
            }

            return this.Max.CompareTo(other.Max);
        }

        public bool Equals(Interval<T> other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Min.Equals(other.Min) && this.Max.Equals(other.Max);
        }

        public bool Contains(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.CompareTo(this.Min) >= 0 && value.CompareTo(this.Max) <= 0;
        }

        public bool Overlaps(Interval<T> interval)
        {
            if (interval == null)
            {
                throw new ArgumentNullException("interval");
            }

            return interval.Max.CompareTo(this.Min) >= 0 && interval.Min.CompareTo(this.Max) <= 0;
        }

        public override bool Equals(object other)
        {
            return this.Equals(other as Interval<T>);
        }

        public override int GetHashCode()
        {
            return (this.Max.GetHashCode() * 1049) ^ (this.Min.GetHashCode() * 883);
        }
    }
}