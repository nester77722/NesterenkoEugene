using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Result
    {
        public Result(bool status)
        {
            Status = status;
        }

        public Result(bool status, string message)
            : this(status)
        {
            Message = message;
        }

        public string Message { get; private set; }

        public bool Status { get; private set; }
    }
}
