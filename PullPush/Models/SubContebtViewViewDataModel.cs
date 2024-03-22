using Interfaces.DataModel;

namespace PullPush.Models
{
    /// <summary>
    /// 紐づけルール一覧表示データモデル
    /// </summary>
    public class SubContebtViewViewDataModel : ISubContentView
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
        /// 適応する取引名
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        public long Subject { get; set; }

        /// <summary>
        /// 科目名
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// 削除フラグ
        /// </summary>
        public long Delete { get; set; }
    }
}
