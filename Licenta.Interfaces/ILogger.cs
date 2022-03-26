using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Interfaces
{
    public interface ILogger
    {
        void Initialize();
        void Info(string message);
        void Error(string message, Exception ex = null);
        void Warning(string message);
    }
}
