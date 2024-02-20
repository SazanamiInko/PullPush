using Interfaces.Service;
using Microsoft.Extensions.Logging;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using System.Diagnostics;

namespace Common
{
    /// <summary>
    /// ロギングサービス
    /// </summary>
    public class LoggingService: ILoggerService
    {
        #region プロパティ
        /// <summary>
        /// ロガー
        /// </summary>
        public ILogger Logger { get; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LoggingService()
        {
            ILoggerFactory factory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddNLog(this.CreateLogFavtory());
            });

            this.Logger = factory.CreateLogger(Util.GetAppName());
        }
        #endregion


        /// <summary>
        /// NLog設定
        /// </summary>
        /// <returns></returns>
        public LoggingConfiguration CreateLogFavtory()
        {
            // NLogでファイル出力するための設定
            var config = new NLog.Config.LoggingConfiguration();

            string logFilename = Process.GetCurrentProcess().ProcessName + ".log";
            string path = "C:\\Users\\Public\\Documents\\Log\\PullPush\\";


            // ログのファイルの出力先を設定
            var logFile = new FileTarget("logfile")
            {
                FileName = path + logFilename,

                // デフォルトのレイアウトです
                Layout = "${longdate},${level:uppercase=true},${logger},${message:withexception=false}\r\n"
            };

            // ログの出力レベルを設定
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logFile);

            return config;
        }

        #region メソッド
        /// <summary>
        /// ログの記載
        /// </summary>
        /// <param name="action"></param>
        public void WriteLog(Action action)
        {
            var caller = new System.Diagnostics.StackFrame(1, false);
            var methodInfo = caller.GetMethod();
            string className = methodInfo.DeclaringType.FullName;
            string methodName = methodInfo.Name;
            try
            {
                Logger.LogInformation($"{className} {methodName} Start");
                action.Invoke();
                Logger.LogInformation($"{className} {methodName} End");
            }
            catch (Exception ex)
            {
                Logger.LogInformation($"{className} {methodName} Error End");
                Logger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// ログの記載
        /// </summary>
        /// <param name="message"></param>
        public void WriteLog(string message)
        {
            Logger.LogInformation(message);
        }

        /// <summary>
        /// エラーログ
        /// </summary>
        /// <param name="exception"></param>
        public void writeLog(Exception exception)
        {
            Logger.LogError(exception.Message);
        }
        #endregion
    }
}
