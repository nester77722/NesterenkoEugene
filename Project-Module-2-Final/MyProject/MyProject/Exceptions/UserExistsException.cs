using System;

namespace MyProject.Exceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException()
            : base()
        {
        }

        public UserExistsException(string message)
            : base(message)
        {
        }
    }
}
