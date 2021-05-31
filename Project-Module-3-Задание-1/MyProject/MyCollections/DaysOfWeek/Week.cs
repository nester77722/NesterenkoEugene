using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections.DaysOfWeek
{
    public class Week : IEnumerable
    {
        private string[] _days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public IEnumerator GetEnumerator()
        {
            return new WeekEnumerator(_days);
        }
    }
}
