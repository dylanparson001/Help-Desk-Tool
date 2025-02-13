using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Logger
{
    public interface ILoggerFactory
    {
        ILogger CreateContextualLogger(string context);
    }
}
