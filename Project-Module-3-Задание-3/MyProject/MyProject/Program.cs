using System;
using Logger;
using Observers;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BusinessClass businessClass = new BusinessClass();
            LoggerObserver loggerObserver = new LoggerObserver();

            businessClass.Observers += loggerObserver.LogNotyfies;
            businessClass.BusinessMethod1();
            businessClass.BusinessMethod2();
            businessClass.BusinessMethod3();
        }
    }
}
