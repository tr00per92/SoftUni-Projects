using System;
using System.Collections.Generic;
using Geography.CodeFirst.Data;

namespace Geography.ConsoleClient
{
    public class MountainModel
    {
        public string MountainName { get; set; }

        public ICollection<string> Countries { get; set; }

        public ICollection<object> Peaks { get; set; }
    }
}
