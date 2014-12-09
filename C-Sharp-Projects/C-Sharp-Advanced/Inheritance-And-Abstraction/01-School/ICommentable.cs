using System.Collections.Generic;

namespace _01_School
{
    public interface ICommentable
    {
        IList<string> Comments { get; set; }

        void AddComment(string comment);
    }
}
