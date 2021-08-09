using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Exceptions
{
    public class ReqresClientException : Exception
    {
        public ReqresClientException(Exception innerException, string message)
            : base(message, innerException)
        {
        }

    }
}
