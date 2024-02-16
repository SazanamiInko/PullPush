using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DataModel
{
    /// <summary>
    /// 引き出し/預け入れ情報
    /// </summary>
    public interface IPullPush
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
        /// 備考
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// ラベル
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 銀行フラグ
        /// </summary>
        public long FromBank { get; set; }
    }
}
