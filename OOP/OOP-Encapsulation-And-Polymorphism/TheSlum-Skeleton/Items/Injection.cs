﻿using System;

namespace TheSlum
{
    public class Injection : Bonus
    {
        public Injection(string id) : base(id, 200, 0, 0)
        {
            this.Countdown = 3;
        }
    }
}
