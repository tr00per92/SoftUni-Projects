using System;

namespace TheSlum
{
    public class Pill : Bonus
    {
        public Pill(string id) : base(id, 0, 0, 100)
        {
            this.Countdown = 1;
        }
    }
}
