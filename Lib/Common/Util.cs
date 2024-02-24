using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        /// <summary>
        /// プロセス名の取得
        /// </summary>
        /// <returns>プロセス名  </returns>
        public static string GetAppName()
        {
            return Process.GetCurrentProcess().ProcessName;
        }

        /// <summary>
        /// NULL許容型を変換
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static long ConvertNullable(long? source)
        {
            return source.HasValue ? source.Value : 0;
        }
        /// <summary>
        /// NULLは空文字に変換
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ConertString(string source)
        {
            return string.IsNullOrEmpty(source)?string.Empty:source; ;
        }
    }
}
