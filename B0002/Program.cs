﻿// See https://aka.ms/new-console-template for more information

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

    //UFJ銀行ファイルを読み込む
    var response = API.LoadMituiFile();
    ;
    //失敗したら終わり
    if (!response.Success)
    {
        throw new BusinessException(response.Message);
    }

    if (response is LoadMituiResponse)
    {
        LoadMituiResponse res = (LoadMituiResponse)response;

        //PullPushに登録
        var addresponse = API.AddPullPush(res.PullPushes);

        //失敗したら終わり
        if (!response.Success)
        {
            throw new BusinessException(addresponse.Message);
        }
        else
        {
            if (addresponse is CommonResponse)
            {
                CommonResponse addRes = (CommonResponse)addresponse;

                logging.WriteLog($"{addRes.Count}件のデータを処理しました");
            }

            logging.WriteLog("OK");
        }
        logging.WriteLog("End");

    }
}
catch (Exception ex)
{
    logging.writeLog(ex);
    logging.WriteLog("Error End");
}
