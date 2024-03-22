using Interfaces.DataModel;

namespace FLayer.Responses
{
    /// <summary>
    /// 紐づけルール一覧取得レスポンス
    /// </summary>
    public class SubContentsResponse : BaseResponse
    {
        #region プロパティ
        /// <summary>
        /// 紐づけルール一覧
        /// </summary>
        public List<ISubContentView> Items { get; }
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SubContentsResponse()
        {
            Items = new List<ISubContentView>();
        }

    }
}
