using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
