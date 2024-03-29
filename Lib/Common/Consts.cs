﻿namespace Common
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
            /// <summary>
            /// 三井銀行ファイルパス
            /// </summary>
            public const string MITUIFILE = @"C:\Users\Public\Documents\Data\PullPush\mitui.csv";

            /// <summary>
            /// UFJファイル
            /// </summary>
            public const string UFJFILE = @"C:\Users\Public\Documents\Data\PullPush\UFJ.csv";
        
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

            /// <summary>
            /// UFJダウンロードファイルレイアウト
            /// </summary>
            public static class UFJ
            {
                /// <summary>
                /// 年月日 
                /// </summary>
                public const int DATE = 0;

                /// <summary>
                /// タイトル
                /// </summary>
                public const int TITLE = 1;
                /// <summary>
                /// 内容
                /// </summary>
                public const int CONTENT = 2;

                /// <summary>
                /// 引出し
                /// </summary>
                public const int PULL = 3;

                /// <summary>
                /// 預入れ
                /// </summary>
                public const int PUSH = 4;


                /// <summary>
                /// 残高
                /// </summary>
                public const int REMAIN = 5;


                /// <summary>
                /// メモ
                /// </summary>
                public const int MEMO = 6;

                /// <summary>
                /// 区分
                /// </summary>
                public const int KBN1 = 7;

                /// <summary>
                /// 区分
                /// </summary>
                public const int KBN2 = 8;
            }
        }

        /// <summary>
        /// 区分
        /// </summary>
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

            /// <summary>
            /// 銀行
            /// </summary>
            public static class Bank
            {
                /// <summary>
                /// 三井住友銀行
                /// </summary>
                public const int MITUI = 1;

                /// <summary>
                /// UFJ銀行
                /// </summary>
                public const int UFJ = 2;
            }

            /// <summary>
            /// 入出金方向
            /// </summary>
            public static class PullPushKbn
            {
                /// <summary>
                /// 引出
                /// </summary>
                public const int PULL = 0;

                /// <summary>
                /// 預入
                /// </summary>
                public const int PUSH=1; 
            }

            /// <summary>
            /// 税対象
            /// </summary>
            public static class Tax
            {
                /// <summary>
                /// 対象
                /// </summary>
                public const int IN = 1;

                /// <summary>
                /// 対象外
                /// </summary>
                public const int OUT = 0;
            }

            /// <summary>
            /// ルール区分
            /// </summary>
            public static class RuleKbn
            {
                /// <summary>
                /// 未分類
                /// </summary>
                public const int MIBUNRUI = -1;

                /// <summary>
                /// 手動
                /// </summary>
                public const int MANUAL = 0;
            }

            /// <summary>
            /// 削除フラグ
            /// </summary>
            public static class DeleteKbn
            {
                /// <summary>
                /// 削除済み
                /// </summary>
                public const int DELETED = 1;
            }
        }
    }
}
