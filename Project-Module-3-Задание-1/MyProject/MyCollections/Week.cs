using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class Week
    {
        private string[] _days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private int _position = -1;

        public IEnumerator<string> GetEnumerator()
        {
            while (true)
            {
                if (_position < _days.Length - 1)
                {
                    _position++;
                    yield return _days[_position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }

        private void Reset()
        {
            _position = -1;
        }
    }
}
