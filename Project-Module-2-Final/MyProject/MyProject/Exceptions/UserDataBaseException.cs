using System;

namespace MyProject.Exceptions
{
    public class UserDataBaseException : Exception
    {
        public UserDataBaseException()
            : base()
        {
        }

        public UserDataBaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
