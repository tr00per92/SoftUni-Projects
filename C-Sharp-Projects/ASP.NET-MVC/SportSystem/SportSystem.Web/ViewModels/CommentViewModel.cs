using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using SportSystem.Common.Mappings;
using SportSystem.Models;

namespace SportSystem.Web.ViewModels
{
    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        [DisplayName("Created On")]
        public DateTime DateTime { get; set; }

        public string AuthorEmail { get; set; }
    }
}