// See https://aka.ms/new-console-template for more information
using Common;
using FLayer.APIs;
using FLayer.Responses;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

var logging = new LoggingService();

try
{
    //処理
    //ログの初期化
    API.InitializeAPI(logging);
    logging.WriteLog("Start");
    API.Grouping();
    logging.WriteLog("OK");
    
    logging.WriteLog("End");
}
catch (Exception ex)
{
    logging.writeLog(ex);
logging.WriteLog("Error End");
}