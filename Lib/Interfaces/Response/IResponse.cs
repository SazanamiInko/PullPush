namespace Interfaces.Response
{
    /// <summary>
    /// レスポンス
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// 成功フラグ
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get; set; }
    }
}
