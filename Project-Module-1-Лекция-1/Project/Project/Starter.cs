using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project
{
    public class Starter
    {
        private Actions _actions;

        private Logger _logger;

        public Starter()
        {
            _actions = new Actions();

            _logger = Logger.Instance;
        }

        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);

                int random = new Random().Next(1, 4);

                switch (random)
                {
                    case 1:
                        {
                            _actions.InfoResult();
                            break;
                        }

                    case 2:
                        {
                            _actions.WarningResult();
                            break;
                        }

                    case 3:
                        {
                            _logger.AddLog(LogType.Error, _actions.ErrorResult().Message);
                            break;
                        }
                }
            }

            Console.WriteLine(_logger.GetLogs());
        }
    }
}
