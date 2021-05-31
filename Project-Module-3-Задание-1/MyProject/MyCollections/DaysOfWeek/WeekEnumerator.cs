using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections.DaysOfWeek
{
    public class WeekEnumerator : IEnumerator
    {
        private string[] _days;
        private int _position = -1;

        public WeekEnumerator(string[] days)
        {
            _days = days;
        }

        public object Current
        {
            get
            {
                return _days[_position];
            }
        }

        public bool MoveNext()
        {
            if (_position < _days.Length - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
