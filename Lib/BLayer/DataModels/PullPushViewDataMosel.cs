using Interfaces.DataModel;

namespace BLayer.DataModels
{
    public class PullPushViewDataMosel: IPullPushView
    {
        /// <summary>
        /// 管理番号
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 取引年
        /// </summary>
        public long Year { get; set; }

        /// <summary>
        /// 取引月
        /// </summary>
        public long Month { get; set; }

        /// <summary>
        /// 取引日
        /// </summary>
        public long Day { get; set; }

        /// <summary>
        /// 取引内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 引き出し
        /// </summary>
        public long Pull { get; set; }

        /// <summary>
        /// 預け入れ
        /// </summary>
        public long Push { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        public long Subject { get; set; }

        /// <summary>
        /// 科目名
        /// </summary>
        public string SubjectName { get; set; }
    }
}
