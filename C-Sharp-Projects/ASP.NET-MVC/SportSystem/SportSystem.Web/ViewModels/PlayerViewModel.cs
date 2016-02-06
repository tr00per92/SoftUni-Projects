using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels
{
    public class PlayerViewModel : IMapFrom<Player>
    {
        public string Name { get; set; }

        [DisplayName("Born")]
        public DateTime DateOfBirth { get; set; }

        public decimal Height { get; set; }
    }
}