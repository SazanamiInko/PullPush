namespace Common
{
    /// <summary>
    /// ビジネスロジック例外
    /// </summary>
    public class BusinessException:Exception
    {
        #region コンストラクタ

        /// <summary>
        /// ビジネスロジック例外のコンストラクタ
        /// </summary>
        /// <param name="message">例外メッセージ</param>
        public BusinessException(string message) : base(message) { }

        #endregion
    }
}
