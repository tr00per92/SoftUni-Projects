namespace BestLecturesSchedule
{
    using System;

    public class Lecture : IComparable<Lecture>
    {
        public Lecture(string name, int start, int end)
        {
            this.Name = name;
            this.Start = start;
            this.End = end;
        }

        public string Name { get; }

        public int Start { get; }

        public int End { get; }

        public int CompareTo(Lecture other)
        {
            return this.End.CompareTo(other.End);
        }

        public override string ToString()
        {
            return $"{this.Start}-{this.End} -> {this.Name}";
        }
    }
}
