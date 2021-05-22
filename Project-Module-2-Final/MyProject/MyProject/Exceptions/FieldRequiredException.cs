using System;

namespace MyProject.Exceptions
{
    public class FieldRequiredException : Exception
    {
        public FieldRequiredException()
            : base()
        {
        }

        public FieldRequiredException(string message)
            : base(message)
        {
        }
    }
}
