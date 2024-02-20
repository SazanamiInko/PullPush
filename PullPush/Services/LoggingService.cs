using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using FLayer.APIs;
using Common;

namespace PullPush.Services
{
    /// <summary>
    /// ロギングサービス
    /// </summary>
    public class LoggingService
    {
        private readonly ILogger _logger;

        public ILogger Logger { get; }

        public LoggingService()
        {
            ILoggerFactory factory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddNLog(API.CreateLoggingConfiguration());
            } );

            factory.CreateLogger(Util.GetAppName());
        }
    }
}
