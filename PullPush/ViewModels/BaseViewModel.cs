namespace PullPush.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    #region メッセージ

    /// <summary>
    /// メッセージ
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Messageアクション
    /// </summary>
    public Action Messageaction { get; set; }
    #endregion

    #region プロパティ

    /// <summary>
    /// ロギングサービス
    /// </summary>
    protected LoggingService Logging { get; set; }

    #endregion

    #region コンストラクタ

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logging"></param>
    public BaseViewModel(LoggingService logging)
    {
        this.Logging = logging;
    }


    #endregion

    #region メソッド

    /// <summary>
    /// メッセージの表示
    /// </summary>
    /// <param name="message"></param>
    public void DisplayAlert(string message)
    {
        this.Message = message;
        this.Messageaction.Invoke();
    }
    #endregion
}
