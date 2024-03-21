using Interfaces.DataModel;

namespace FLayer.Responses
{
    /// <summary>
    /// UFJ銀行ファイル読み取りレスポンス
    /// </summary>
    public class LoadUFJResponse : BaseResponse
    {
        /// <summary>
        /// 読み込んだ内容
        /// </summary>
        public List<IPullPush> PullPushes { set; get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LoadUFJResponse()
        {
            PullPushes = new List<IPullPush>();
        }
    }
}
