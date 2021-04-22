using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Actions
    {
        private Logger _logger;

        public Actions()
        {
            _logger = Logger.Instance;
        }

        public Result InfoResult()
        {
            var result = new Result(true, string.Empty);

            _logger.AddLog(LogType.Info, result.Message);

            return result;
        }

        public Result WarningResult()
        {
            var result = new Result(true, string.Empty);

            _logger.AddLog(LogType.Warning, result.Message);

            return result;
        }

        public Result ErrorResult()
        {
            var result = new Result(true, "I broke a logic");

            _logger.AddLog(LogType.Error, result.Message);

            return result;
        }
    }
}
