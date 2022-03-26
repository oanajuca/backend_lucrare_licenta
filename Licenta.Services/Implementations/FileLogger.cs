using Licenta.Infrastructure.Wrappers;
using Licenta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Services.Implementations
{
    public class FileLogger : ILogger
    {
        public FileLogger()
        {
            Logger.Initialize();
        }

        public void Error(string message, Exception ex = null)
        {
            Logger.Error(message, ex);
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }

        public void Initialize()
        {
            Logger.Initialize();
        }

        public void Warning(string message)
        {
            Logger.Warning(message);
        }
    }
}
