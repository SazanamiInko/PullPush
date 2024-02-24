using Interfaces.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLayer.Responses
{
    /// <summary>
    /// 引出預入レスポンス
    /// </summary>
    public class PullPushResponse : BaseResponse
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>

        public PullPushResponse() 
        {
            this.Items = new List<IPullPushView>();
        }

        #region プロパティ
        /// <summary>
        /// 科目一覧
        /// </summary>
        public List<IPullPushView> Items { get; }
        #endregion

    }
}
