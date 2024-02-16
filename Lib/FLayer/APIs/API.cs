using BLayer.Logics;
using DLayer.Models;
using FLayer.Responses;
using Interfaces.Response;
using Microsoft.Extensions.Logging;


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
        }

        #endregion

        #region API
        /// <summary>
        /// 三井住友銀行ファイルの読み込み
        /// </summary>
        /// <returns></returns>
        public static IResponse LosdMituiFile()
        {
            LoadMituiResponse res =new LoadMituiResponse();

            try
            {
              var pullpushes=  renkeiLogic.LosdMituiFile();
                res.PullPushes.AddRange(pullpushes);    
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
