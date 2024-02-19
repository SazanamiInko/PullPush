﻿using BLayer.Logics;
using Common;
using DLayer.Models;
using FLayer.Responses;
using Interfaces.DataModel;
using Interfaces.Response;
using Microsoft.Extensions.Logging;
using NLog.Config;

namespace FLayer.APIs
{
    /// <summary>
    /// API
    /// </summary>
    public  class API
    {

        #region メンバー

        /// <summary>
        /// コンテキスト
        /// </summary>
        private static PullPushContext context;

        /// <summary>
        /// 連携ロジック
        /// </summary>
        private static RenkeiLogic renkeiLogic;

        /// <summary>
        /// 引き出し情報
        /// </summary>
        private static PullPushLogic pullPushLogic;

        /// <summary>
        /// 科目ロジック
        /// </summary>
        private static SubjectLogic subjectLogic;

        /// <summary>
        /// ログ
        /// </summary>
        private static Logging logging;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static API()
        {
            context = new PullPushContext();
            renkeiLogic = new RenkeiLogic();
            renkeiLogic.Context = context;
            pullPushLogic = new PullPushLogic();
            pullPushLogic.Context = context;
            subjectLogic=new SubjectLogic();
            subjectLogic.Context = context;
            logging = new Logging();
        }

        #endregion

        #region API

        /// <summary>
        /// ログ取得
        /// </summary>
        /// <returns></returns>
        public static LoggingConfiguration CreateLoggingConfiguration()
        {
            return logging.CreateLogFavtory();
        }

        /// <summary>
        /// 三井住友銀行ファイルの読み込み
        /// </summary>
        /// <returns></returns>
        public static IResponse LoadMituiFile()
        {
            LoadMituiResponse res =new LoadMituiResponse();

            try
            {
              var pullpushes=  renkeiLogic.LoadMituiFile();
                res.PullPushes.AddRange(pullpushes);    
            }
            catch (Exception ex)
            {
                res.SetMessage(ex);
            }

            return res;
         }

       /// <summary>
       /// 引出預入登録
       /// </summary>
       /// <param name="pullPushs"></param>
       /// <returns></returns>
        public static IResponse AddPullPush(List<IPullPush> pullPushs)
        {
            CommonResponse res = new CommonResponse();

            try
            {
                var result = pullPushLogic.InsertPullPushs(pullPushs);
                res.Count = result;
            }
            catch (Exception ex)
            {
                res.SetMessage(ex);
            }

            return res;

        }

        /// <summary>
        /// 科目登録
        /// </summary>
        /// <param name="subject">科目</param>
        /// <returns></returns>
        public static IResponse AddSubject(ISubject subject)
        {

            CommonResponse res = new CommonResponse();
            try
            {
                subjectLogic.InsertSubject(subject);
                res.Count = 1;
            }
            catch (Exception ex)
            {
                res.SetMessage(ex);
            }
            return res;
        }

        #endregion
    }
}
