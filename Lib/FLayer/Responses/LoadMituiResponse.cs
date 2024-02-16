using Interfaces.DataModel;
using Interfaces.Response;

namespace FLayer.Responses
{
    /// <summary>
    /// 三井住友銀行ファイル読みこみAPIレスポンス
    /// </summary>
    public class LoadMituiResponse : BaseResponse
    {
        /// <summary>
        /// 読み込んだ内容
        /// </summary>
       public List<IPullPush> PullPushes { set; get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LoadMituiResponse()
        {
            PullPushes = new List<IPullPush>();
        }
    }
}
