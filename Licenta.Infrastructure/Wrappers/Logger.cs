using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace Licenta.Infrastructure.Wrappers
{
    public static class Logger
    {
        private static ILog _log = null;

        public static void Initialize()
        {
            if (HttpContext.Current == null)
            {
                _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            else
            {
                var applicationPath = HttpContext.Current.Server.MapPath("~");
                log4net.Config.XmlConfigurator.Configure(new FileInfo(Path.Combine(applicationPath, "log4Net.config")));

                _log = LogManager.GetLogger("Log4NetTester");
            }
        }

        public static void Info(string message)
        {
            _log.Info(message);
        }

        public static void Error(string message, Exception ex = null)
        {
            _log.Error(message, ex);
        }

        public static void Warning(string message)
        {
            _log.Warn(message);
        }
    }
}