using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
