using Interfaces.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLayer.Responses
{
    /// <summary>
    /// 応答
    /// </summary>
    public abstract class BaseResponse : IResponse
    {
        #region プロパティ
        /// <summary>
        /// 成功フラグ
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get; set; } = "";
        #endregion

        #region メソッド
        /// <summary>
        /// メッセージをセットする
        /// </summary>
        /// <param name="ex">例外</param>
        public void SetMessage(Exception ex)
        {
            this.Success = false;
            this.Message = ex.Message;
        }
        #endregion

    }
}
