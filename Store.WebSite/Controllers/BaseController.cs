using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WebSite.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Instance of ErrorLog
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Error Levels 
        /// </summary>
        public enum ErrorLogLevel
        {
            FATAL,
            ERROR,
            WARN,
            INFO,
            DEBUG
        }

        /// <summary>
        /// Save errorlog with log4Net
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="message">string message</param>
        /// <param name="errorLogLevel">Level error</param>
        public void SaveError(Exception ex, string message, ErrorLogLevel errorLogLevel)
        {

            switch (errorLogLevel)
            {
                case ErrorLogLevel.FATAL:
                    log.Fatal(message, ex);
                    break;
                case ErrorLogLevel.ERROR:
                    log.Error(message, ex);
                    break;
                case ErrorLogLevel.WARN:
                    log.Warn(message, ex);
                    break;
                case ErrorLogLevel.INFO:
                    log.Info(message, ex);
                    break;
                case ErrorLogLevel.DEBUG:
                    log.Debug(message, ex);
                    break;
                default:
                    break;
            }
        }
    }
}