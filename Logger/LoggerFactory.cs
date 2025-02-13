using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Logger
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly ILogger _logger;

        public LoggerFactory(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger CreateContextualLogger(string context)
        {
            return _logger.ForContext(context, true);
        }
    }
}
