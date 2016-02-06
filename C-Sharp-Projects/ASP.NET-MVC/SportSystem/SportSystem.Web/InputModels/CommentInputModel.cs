using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.InputModels
{
    public class CommentInputModel : IMapTo<Comment>
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public int MatchId { get; set; }
    }
}
