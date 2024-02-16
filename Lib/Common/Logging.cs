using NLog.Config;
using NLog.Targets;
using System.Diagnostics;

namespace Common
{
    public class Logging
    {
        public LoggingConfiguration CreateLogFavtory()
        {
            // NLogでファイル出力するための設定
            var config = new NLog.Config.LoggingConfiguration();

            string logFilename=Process.GetCurrentProcess().ProcessName+".log";
            string path = "C:\\Users\\Public\\Documents\\Log\\PullPush\\";

            
            // ログのファイルの出力先を設定
            var logFile = new FileTarget("logfile")
            {
                FileName = path+logFilename,
                
                // デフォルトのレイアウトです
                Layout = "${longdate},${level:uppercase=true},${logger},${message:withexception=false}\r\n"
            };

            // ログの出力レベルを設定
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logFile);

            return config;
        }
    }
}
