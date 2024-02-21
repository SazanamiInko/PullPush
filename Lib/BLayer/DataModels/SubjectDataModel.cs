using Interfaces.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.DataModels
{
    /// <summary>
    /// 科目マスタ
    /// </summary>
    public class SubjectDataModel : ISubject
    {
        /// <summary>
        /// 管理番号
        /// </summary>
        public long Id { get; set; }
       
        /// <summary>
        /// 科目名
        /// </summary>
        public string Name { get; set; }
       
        /// <summary>
        /// 引出預入区分
        /// </summary>
        public long PullPushKbn { get; set; }

        /// <summary>
        /// 税対象区分
        /// </summary>
        public long TaxTargetFlg { get; set; }
    }
}
