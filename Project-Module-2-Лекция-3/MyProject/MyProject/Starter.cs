using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject
{
    public class Starter
    {
        private Logger _logger;

        public Starter()
        {
            _logger = Logger.Instance;
        }

        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);

                int random = new Random().Next(1, 4);

                try
                {
                    switch (random)
                    {
                        case 1:
                            {
                                Actions.StartMethod();
                                break;
                            }

                        case 2:
                            {
                                Actions.Business();
                                break;
                            }

                        case 3:
                            {
                                Actions.Exception();
                                break;
                            }
                    }
                }
                catch (BusinessException ex)
                {
                    string logMessage = $"Action got this custom Exception: {ex.Message}";
                    _logger.AddLog(LogTypes.Warning, logMessage);
                }
                catch (Exception ex)
                {
                    string logMessage = $"Action failed by reason: {ex.StackTrace}";
                    _logger.AddLog(LogTypes.Error, logMessage);
                }
            }
        }
    }
}
