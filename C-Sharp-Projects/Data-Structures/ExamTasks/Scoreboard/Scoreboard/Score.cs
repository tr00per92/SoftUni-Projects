namespace Scoreboard
{
    using System;

    public class Score : IComparable<Score>
    {
        public int Points { get; set; }

        public string Name { get; set; }

        public int CompareTo(Score other)
        {
            var compare = this.Points.CompareTo(other.Points);
            if (compare != 0)
            {
                return compare;
            }

            return string.Compare(other.Name, this.Name, StringComparison.InvariantCulture);
        }

        public override string ToString()
        {
            return this.Name + " " + this.Points;
        }
    }
}
