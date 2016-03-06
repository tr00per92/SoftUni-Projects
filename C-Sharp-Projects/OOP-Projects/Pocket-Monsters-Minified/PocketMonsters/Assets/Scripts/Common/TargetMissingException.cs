namespace Common
{
    using System;

    public class TargetMissingException : ApplicationException
    {
        public TargetMissingException(string message)
            : base(message)
        { }
    }
}
