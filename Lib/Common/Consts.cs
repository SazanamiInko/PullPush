﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 定数
    /// </summary>
    public static class Consts
    {
        /// <summary>
        /// パス定義
        /// </summary>
        public static class Paths
        {
            public const string MITUIFILE = @"C:\Users\Public\Documents\Data\PullPush\mitui.csv";
        }

        /// <summary>
        /// ファイルレイアウト定義
        /// </summary>
        public static class FL
        {
            /// <summary>
            /// 三井住友銀行ダウンロードファイルレイアウト
            /// </summary>
            public static class MITUI
            {
                /// <summary>
                /// 年月日 
                /// </summary>
                public const int DATE = 0;

                /// <summary>
                /// 引出し
                /// </summary>
                public const int PULL = 1;

                /// <summary>
                /// 預入れ
                /// </summary>
                public const int PUSH = 2;

                /// <summary>
                /// 内容
                /// </summary>
                public const int CONTENT = 3;

                /// <summary>
                /// 残高
                /// </summary>
                public const int REMAIN = 4;

                /// <summary>
                /// メモ
                /// </summary>
                public const int MEMO = 5;

                /// <summary>
                /// ラベル
                /// </summary>
                public const int LABEL = 6;
            }
        }

        public static class Kbn
        {
            /// <summary>
            /// 銀行連動区分
            /// </summary>
            public static class FromBankKbn
            {
                /// <summary>
                /// 銀行連動データ
                /// </summary>
                public const int FromBank = 1;
            }
        }
    }
}
