using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// ユーティリティ
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// 文字列から日時に変換
        /// </summary>
        /// <param name="dateStr">変換する文字列</param>
        /// <returns>変換した日時</returns>
        public static DateTime convertStrToDateTime(string dateStr)
        {
            //文字列からDateTimeに変換する
            return Convert.ToDateTime(dateStr);
        }
    }
}
