using Common.Contracts;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Providers
{
    public class Logger : ILogger
    {
        #region Fields
        private static Logger instance;
        private static log4net.ILog log;

        //Singleton
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logger();
                return instance;
            }
        }
        #endregion

        Logger()
        {
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public bool LogMessage(LOG_TYPE logType, String message)
        {
            try
            {
                switch (logType)
                {
                    case LOG_TYPE.DEBUG:
                        log.Debug(message);
                        break;
                    case LOG_TYPE.INFO:
                        log.Info(message);
                        break;
                    case LOG_TYPE.WARN:
                        log.Warn(message);
                        break;
                    case LOG_TYPE.ERROR:
                        log.Error(message);
                        break;
                    case LOG_TYPE.FATAL:
                        log.Fatal(message);
                        break;
                    default:
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
