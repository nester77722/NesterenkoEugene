using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
