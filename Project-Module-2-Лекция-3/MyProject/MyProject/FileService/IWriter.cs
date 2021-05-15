using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public interface IWriter
    {
        public void Write(string message);

        public string GetBuffer();
    }
}
