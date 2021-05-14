using System;
using static System.Reflection.MethodBase;

namespace MyProject
{
    public static class Actions
    {
        private static Logger _logger = Logger.Instance;

        public static void StartMethod()
        {
            _logger.AddLog(LogTypes.Info, $"Message from {GetCurrentMethod().Name}");
        }

        public static void Business()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public static void Exception()
        {
            throw new Exception("I broke a logic");
        }
    }
}
