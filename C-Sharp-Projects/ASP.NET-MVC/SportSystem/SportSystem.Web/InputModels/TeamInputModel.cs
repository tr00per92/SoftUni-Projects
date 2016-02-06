using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.InputModels
{
    public class TeamInputModel : IMapTo<Team>
    {
        [Required]
        public string Name { get; set; }

        public string Nickname { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        public DateTime? Founded { get; set; }

        public IEnumerable<int> PlayerIds { get; set; }
    }
}
