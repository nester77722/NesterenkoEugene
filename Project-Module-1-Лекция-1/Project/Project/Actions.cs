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

            _logger.AddLog(LogTypes.Info, result.Status, result.Message);

            return result;
        }

        public Result WarningResult()
        {
            var result = new Result(true, string.Empty);

            _logger.AddLog(LogTypes.Warning, result.Status, result.Message);

            return result;
        }

        public Result ErrorResult()
        {
            var result = new Result(false, "I broke a logic");

            _logger.AddLog(LogTypes.Error, result.Status, result.Message);

            return result;
        }
    }
}
