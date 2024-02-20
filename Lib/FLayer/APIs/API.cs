﻿using BLayer.Logics;
using Common;
using DLayer.Models;
using FLayer.Responses;
using Interfaces.DataModel;
using Interfaces.Response;
using Interfaces.Service;
using Microsoft.Extensions.Logging;
using NLog.Config;
using System.Runtime.CompilerServices;

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

        private static ILoggerService logging;

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
            
        }

        #endregion

        #region API

        /// <summary>
        /// APIの初期化
        /// </summary>
        /// <param name="logger"></param>
        public static void InitializeAPI(ILoggerService logger)
        {
            logger = logger;
        }

        /// <summary>
        /// 三井住友銀行ファイルの読み込み
        /// </summary>
        /// <returns></returns>
        public static IResponse LoadMituiFile()
        {
            LoadMituiResponse res =new LoadMituiResponse();
            logging.WriteLog(() =>
            {
                try
                {
                    var pullpushes = renkeiLogic.LoadMituiFile();
                    res.PullPushes.AddRange(pullpushes);
                }
                catch (Exception ex)
                {
                    res.SetMessage(ex);
                }
            });
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
            logging.WriteLog(()=>
            {
                try
                {
                    var result = pullPushLogic.InsertPullPushs(pullPushs);
                    res.Count = result;
                }
                catch (Exception ex)
                {
                    res.SetMessage(ex);
                }
            });
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

            logging.WriteLog(() =>
            {
                try
            {
                subjectLogic.InsertSubject(subject);
                res.Count = 1;
            }
            catch (Exception ex)
            {
                res.SetMessage(ex);
            }
            });
            return res;
        }

        #endregion
    }
}
