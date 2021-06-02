using System;
using System.Collections.Generic;
using Observers;

namespace MyProject
{
    public class BusinessClass : Subject
    {
        public void BusinessMethod1()
        {
            Notify($"Message from {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }

        public void BusinessMethod2()
        {
            Notify($"Message from {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }

        public void BusinessMethod3()
        {
            Notify($"Message from {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }
    }
}
