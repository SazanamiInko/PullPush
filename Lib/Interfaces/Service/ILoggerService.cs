using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Service
{
    /// <summary>
    /// ロギングサービス
    /// </summary>
    public interface ILoggerService
    {
        #region メソッド

        /// <summary>
        /// ログを記載する
        /// </summary>
        /// <param name="action">ログを記載するメソッド</param>
        public void WriteLog(Action action);

        /// <summary>
        /// ログを記載
        /// </summary>
        /// <param name="message"></param>
        public void WriteLog(string message);

        /// <summary>
        /// ログを記載
        /// </summary>
        /// <param name="exception"></param>
        public void writeLog(Exception exception);
        #endregion
    }
}
