using BLayer.Logics;
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
    public static class API
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
        /// 取引科目紐づけルールロジック
        /// </summary>
        private static SubContentLogic subontentLogic;


        /// <summary>
        /// ロギング
        /// </summary>
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
            subjectLogic = new SubjectLogic();
            subjectLogic.Context = context;
            subontentLogic = new SubContentLogic();
            subontentLogic.Context = context;
        }

        #endregion

        #region API

        /// <summary>
        /// APIの初期化
        /// </summary>
        /// <param name="logger"></param>
        public static void InitializeAPI(ILoggerService logger)
        {
            logging = logger;
        }

        /// <summary>
        /// 三井住友銀行ファイルの読み込み
        /// </summary>
        /// <returns></returns>
        public static IResponse LoadMituiFile()
        {
            LoadMituiResponse res = new LoadMituiResponse();
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
        /// UFJファイルの読み込み」
        /// </summary>
        /// <returns></returns>
        public static IResponse LoadUFJFile()
        {
            LoadUFJResponse res = new LoadUFJResponse();
            logging.WriteLog(() =>
            {
                try
                {
                    var pullpushes = renkeiLogic.LoadUFJFile();
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
            logging.WriteLog(() =>
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

        /// <summary>
        /// 科目一覧取得
        /// </summary>
        /// <returns>科目一覧応答</returns>
        public static IResponse GetSubjextItems()
        {
            SubjectResponse res = new SubjectResponse();
            logging.WriteLog(() =>
            {
                try
                {
                    var items = subjectLogic.GetSubjectList();

                    items.ForEach(record => res.Items.Add(record));
                }
                catch (Exception ex)
                {
                    res.SetMessage(ex);
                }
            });

            return res;
        }

        /// <summary>
        /// ルール紐づけの登録
        /// </summary>
        /// <param name="subContent"></param>
        /// <returns></returns>
        public static IResponse AddSubContent(ISubContent subContent)
        {
            CommonResponse res = new CommonResponse();

            logging.WriteLog(() =>
            {
                try
                {
                    res.Count = subontentLogic.InsertSubContent(subContent);
                }
                catch (Exception ex)
                {
                    logging.writeLog(ex);
                    res.SetMessage(ex);
                }
            });
            return res;
        }

        /// <summary>
        /// 一覧取得
        /// </summary>
        /// <returns></returns>
        public static IResponse GetPullPush()
        {
            PullPushResponse res = new PullPushResponse();
            logging.WriteLog(() =>
            {
                try
                {
                    var items=pullPushLogic.GetPullPushs();
                    res.Items.AddRange(items);

                }
                catch (Exception ex)
                {
                    logging.writeLog(ex);
                    res.SetMessage(ex);
                }

            });

            return res;
        }

        /// <summary>
        /// 科目一覧取得
        /// </summary>
        /// <param name="kbn">引出預入区分</param>
        /// <param name="addMisentaku">未選択を追加しない場合はfalse</param>
        /// <returns></returns>
        public static IResponse GetSubjectsByKbn(long kbn,bool addMisentaku=true)
        {
            SubjectResponse res = new SubjectResponse();
            logging.WriteLog(() =>
            {
                try
                {
                    var items = subjectLogic.GetSubjectList(kbn);

                    if(addMisentaku)
                    {
                        res.Items.Add(subjectLogic.CreateMisentaku());                    
                    }

                    items.ForEach(record => res.Items.Add(record));
                }
                catch (Exception ex)
                {
                    res.SetMessage(ex);
                }
            });

            return res;
        }

        /// <summary>
        /// 科目設定
        /// </summary>
        /// <param name="id">管理番号</param>
        /// <param name="subject">科目</param>
        /// <returns>レスポンス</returns>
        public static IResponse SetSubject(long id, long subject,long rule)
        {
            CommonResponse res = new CommonResponse();
            try
            {
                res.Count = pullPushLogic.UpdateSubject(id, subject, rule);
            }
            catch (Exception ex)
            {
                res.SetMessage(ex);
            }
            return res;
        }

        /// <summary>
        /// 紐づけルール一覧取得
        /// </summary>
        /// <returns>レスポンス</returns>
        public static IResponse GetSubContent()
        {
            SubContentsResponse res = new SubContentsResponse();
            try
            {
               var items= subontentLogic.GetSubContent();

                items.ForEach(record => res.Items.Add(record));
                
            }
            catch (Exception ex)
            {
                res.SetMessage(ex);
            }

            return res;
        }
    }
    #endregion
}

   
