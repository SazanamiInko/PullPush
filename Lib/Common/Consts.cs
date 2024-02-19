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
            }

            /// <summary>
            /// 入出金方向
            /// </summary>
            public static class Distans
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
        }
    }
}
