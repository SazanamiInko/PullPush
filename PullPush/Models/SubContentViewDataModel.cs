using Interfaces.DataModel;

namespace PullPush.Models
{
    /// <summary>
    /// 取引科目紐づけルール
    /// </summary>
    public class SubContentViewDataModel : ISubContent
    {
        /// <summary>
        /// 管理番号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ルール名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 取引名
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        public long Subject { get; set; }

        /// <summary>
        /// 削除フラグ
        /// </summary>
        public long Delete { get; set; }
    }
}
