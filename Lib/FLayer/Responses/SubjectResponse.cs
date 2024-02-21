using Interfaces.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLayer.Responses
{
    /// <summary>
    /// 科目応答
    /// </summary>
    public class SubjectResponse : BaseResponse
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SubjectResponse() 
        {
            Items = new List<ISubject>();
        }

        #endregion

        #region メソッド
        /// <summary>
        /// 科目一覧
        /// </summary>
        public List<ISubject> Items { get; }
        #endregion

    }
}
