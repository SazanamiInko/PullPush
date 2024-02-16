// See https://aka.ms/new-console-template for more information

using FLayer.APIs;
using FLayer.Responses;
using Interfaces.DataModel;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddNLog(API.CreateLoggingConfiguration());
}
);
//処理
//ログの初期化
var logger=factory.CreateLogger("Program");
logger.LogInformation("Start");

//三井住友銀行ファイルを読み込む
var response = API.LoadMituiFile();

//失敗したら終わり
if (!response.Success)
{
    logger.LogError(response.Message);
    logger.LogInformation("End");
    return;
}

if (response is LoadMituiResponse)
{
    LoadMituiResponse res = (LoadMituiResponse)response;

    //PullPushに登録
    var addresponse = API.AddPullPush(res.PullPushes);

    //失敗したら終わり
    if (!response.Success)
    {
        logger.LogError(response.Message);
        logger.LogInformation("End");
        return;
    }
    else
    {
        if (addresponse is CommonResponse)
        {
            CommonResponse addRes = (CommonResponse)addresponse;

            logger.LogInformation($"{addRes.Count}件のデータを処理しました");
        }

        logger.LogInformation("OK");
    }
    logger.LogInformation("End");
}